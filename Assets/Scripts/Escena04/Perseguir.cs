using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour {

	public float velocidadY;
	public Transform target;
	public GameObject imgVida1, imgVida2, imgVida3;

	int vida;
	float horInput;
	float verInput;
	Rigidbody2D rb;
	Vector2 movement;

	// ==============================
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		movement = new Vector2 ();
		vida = 3;
	}

	// ==============================
	void Update () {

		if (GameManager.tiempo <= 20f) {
			velocidadY = 8;
		}

		if (transform.position.x < target.transform.position.x) {
			horInput = 1;
		} else if (transform.position.x > target.transform.position.x) {
			horInput = -1;
		} else if (transform.position.x == target.transform.position.x) {
			horInput = 0;
		}

		if (vida == 2) {
			imgVida1.SetActive (false);
		} else if (vida == 1) {
			imgVida2.SetActive (false);
		} else if (vida <= 0) {
			imgVida3.SetActive (false);
			//gana el player
		} 
	}

	// ==============================
	void FixedUpdate () {

		movement = rb.velocity;
		movement.x = horInput * 3f;
		movement.y = velocidadY;
		rb.velocity = movement;
	}

	// ==============================
	public void OnCollisionEnter2D (Collision2D col) {
	
		if (col.gameObject.tag == "Obstaculos") {
			vida--;
			Destroy (col.gameObject);
		}
	}
}
