using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour {

	public string escenaActual;
	public string escenaSiguiente;

	// ==================================
	public void Restart () {

		SceneManager.LoadScene (escenaActual);
	}

	// ==================================
	public void PasarEscena () {
	
		SceneManager.LoadScene (escenaSiguiente);
	}
}
