using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	float tiempoInicio;

	public float velocidad;

	// ==================================
	void Start () {

		tiempoInicio = 0;
	}
	
	// ==================================
	void Update () {
	
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (0, ((Time.time - tiempoInicio)*velocidad)%1);
	}
}