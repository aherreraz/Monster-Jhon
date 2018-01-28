using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Correr : MonoBehaviour {

	public ButtonUI btnLeft;
	public ButtonUI btnRight;
	public float velocidad;

	Rigidbody2D rb;
	float direccion;
	float x;

	// ==============================
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
	}

	// ==============================
	void Update () {

		if (btnLeft.pulsado) {
			direccion = -1;
		} else if (btnRight.pulsado) {
			direccion = 1;
		} else {
			direccion = Input.GetAxis ("Horizontal");
		}

		rb.velocity = new Vector2 (direccion*10f, velocidad);

		if (GameManager.instance.tiempo <= 20) {
			velocidad = 8;
		} else if (GameManager.instance.tiempo <= 0) {
			//gameOver
		}
	}

	// ==============================
	public void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Obstaculos") {
			SceneManager.LoadScene ("Escena04");
		}
	}
}

