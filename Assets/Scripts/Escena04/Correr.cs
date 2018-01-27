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

		rb.velocity = new Vector2 (direccion*12f, velocidad);
	}

	// ==============================
	public void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Enemy") {
			SceneManager.LoadScene ("Escena04");
		}
	}
}

