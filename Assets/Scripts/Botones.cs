using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour {

	public string escena;

	// ==================================
	public void Restart () {

		SceneManager.LoadScene (escena);
	}
}
