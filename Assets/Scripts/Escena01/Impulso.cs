using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Impulso : MonoBehaviour {

	public ButtonUI btnLeft;
	public ButtonUI btnRight;
	public GameObject burbujas;
	public float velocidad;
	public float fuerza;

	float direccion;
	Rigidbody2D rb;
	Animator anim;
	Vector2 movimiento;

	// ==================================
	void Start () {

		anim = GetComponent<Animator> ();
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
				anim.SetBool ("Nado", true);
				burbujas.SetActive (true);
				rb.AddForce (new Vector2 (0, -fuerza), ForceMode2D.Impulse);
			} else if (btnRight.pulsado) {
				direccion = 1;
				movimiento.y = fuerza;
				anim.SetBool ("Nado", true);
				burbujas.SetActive (true);
				rb.AddForce (new Vector2 (0, -fuerza), ForceMode2D.Impulse);
			} else {
				direccion = Input.GetAxis ("Horizontal");
				anim.SetBool ("Nado", false);
			}

			movimiento.x = direccion * 10f;
			rb.velocity = movimiento;

			if (GameManager.tiempo <= 0) {
				GameManager.enJuego = false;
				GameManager.tiempo = 5;
				SceneManager.LoadScene ("Escena01");
			}
		}
	}

	// ==================================
	public void OnTriggerEnter2D (Collider2D col ) {

		if (col.tag == "Fin") {
			GameManager.enJuego = false;
			SceneManager.LoadScene ("Escena02");
		}
	}

	// ==================================
	public void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Enemy") {
			GameManager.enJuego = false;
			StartCoroutine (Animacion ());
		}
	}

	// ==================================
	private IEnumerator Animacion () {

		rb.gravityScale = 0;
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		burbujas.SetActive (false);
		anim.SetBool ("Muerto", true);
		yield return new WaitForSeconds (0.7f);
		SceneManager.LoadScene ("Escena01");
	}
}
