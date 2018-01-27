using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulso : MonoBehaviour {

	public ButtonUI btnLeft;
	public ButtonUI btnRight;
	public GameObject ganaste;
	public float velocidad;
	public float fuerza;

	float direccion;
	Rigidbody2D rb;

	Vector2 movimiento;

	// ==================================
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		movimiento = new Vector2 ();
	}
	
	// ==================================
	void Update () {

		if (GameManager.enJuego == true) {

			movimiento = rb.velocity;

			if (btnLeft.pulsado) {
				direccion = -1;
				movimiento.y = fuerza;
				rb.AddForce (new Vector2 (0, -fuerza), ForceMode2D.Impulse);
			} else if (btnRight.pulsado) {
				direccion = 1;
				movimiento.y = fuerza;
			} else {
				direccion = Input.GetAxis ("Horizontal");
			}

			movimiento.x = direccion * 10f;
			rb.velocity = movimiento;
		}
	}

	// ==================================
	public void OnTriggerEnter2D (Collider2D col ) {

		if (col.tag == "Fin") {
			GameManager.enJuego = false;
			ganaste.SetActive (true);
		}
	}
}
