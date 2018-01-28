using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
    public GameObject jhon;
	public static bool enJuego;
	public float tiempo;

	public Text txtTiempo;
    
	private void Awake ()
    {
        instance = this;
		enJuego = true;
        tiempo = LevelManager.instance.GetTimer();
 	}
	
	private void Update ()
    {
        if (enJuego == true)
        {
			tiempo -= Time.deltaTime;
			txtTiempo.text = tiempo.ToString ("f0");
            if (tiempo <= 0)
            {
                jhon.GetComponent<Animator>().SetTrigger("Die");
                LevelManager.instance.ReloadLevelWithDelay(0.7f);
                Destroy(gameObject);
            }
		}
	}
}
