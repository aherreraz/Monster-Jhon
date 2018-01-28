using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	 
	public static GameManager gameManager;
	public static bool enJuego; 
	public static float tiempo;

	public Text txtTiempo;

	// ==================================
	void Start () {

		enJuego = true;
		if (SceneManager.GetActiveScene().name == "Escena01") {
			tiempo = 5;
		} else if (SceneManager.GetActiveScene().name == "Escena04") {
			tiempo = 30;
		}
 	}
	
	// ==================================
	void Update () {

		if (enJuego == true) {
			tiempo -= Time.deltaTime;
			txtTiempo.text = tiempo.ToString ("f0");
		}
	}
}
