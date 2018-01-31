using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Eat : MonoBehaviour
{
    public Stat hungerBar;
    public GameObject Jhon;

    private void Awake()
    {
        hungerBar.Initialize();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == Tags.FOOD)
		{
			collision.GetComponent<Animator>().SetTrigger("Hit");
			hungerBar.Value++;
			Destroy(collision.gameObject, 0.5f);
			if (hungerBar.Value >= hungerBar.MaxVal)
				LevelManager.instance.LoadNextLevelWithDelay(0.5f);
		}
		else if (collision.gameObject.tag == Tags.ENEMY)
        {
            collision.GetComponent<Animator>().SetTrigger("Hit");
            Destroy(collision.gameObject, 0.5f);
            Jhon.GetComponent<Animator>().SetTrigger("Die");
        }
    }
}
