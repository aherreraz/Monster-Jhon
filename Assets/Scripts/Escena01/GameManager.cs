using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	 
	public static GameManager gameManager;
	public static bool enJuego; 
	public static float tiempo;

	public Text txtTiempo;

	// ==================================
	void Start () {

		enJuego = true;
		tiempo = 5;
	}
	
	// ==================================
	void Update () {

		if (enJuego == true) {
			tiempo -= Time.deltaTime;
			txtTiempo.text = tiempo.ToString ("f0");
		}
	}
}
