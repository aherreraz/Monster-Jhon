using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : MonoBehaviour
{
    public Stat BarraHambre;
    public GameObject Jhon;

    private void Awake()
    {
        BarraHambre.Initialize();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mosca>() || collision.GetComponent<Cucaracha>())
        {
            collision.GetComponent<Animator>().SetTrigger("Die");
            Destroy(collision.gameObject, 0.5f);

            if (collision.GetComponent<Mosca>())
            {
                BarraHambre.Value++;
                collision.GetComponent<Mosca>().enabled = false;
            }
            if (collision.GetComponent<Cucaracha>())
            {
                BarraHambre.Value += 2;
                collision.GetComponent<Cucaracha>().enabled = false;
                collision.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
            if (BarraHambre.Value >= BarraHambre.MaxVal)
                LevelManager.instance.LoadNextLevelWithDelay(0.5f);
        }
        else if (collision.GetComponent<Paloma>() || collision.GetComponent<Gato>())
        {
            collision.GetComponent<Animator>().SetTrigger("GetHit");
            Destroy(collision.gameObject, 0.5f);
            Jhon.GetComponent<Animator>().SetTrigger("Die");
            LevelManager.instance.ReloadLevelWithDelay(0.7f);

            if (collision.GetComponent<Paloma>())
                collision.GetComponent<Paloma>().enabled = false;
            if (collision.GetComponent<Gato>())
            {
                collision.GetComponent<Gato>().enabled = false;
                collision.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }
    }
}
