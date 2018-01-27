using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour {

	public float velocidad;
	public Transform target;

	float horInput;
	float verInput;
	Rigidbody2D rb;
	Vector2 movement;

	// ==============================
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		movement = new Vector2 ();
	}

	// ==============================
	void Update () {

		if (transform.position.x < target.transform.position.x) {
			horInput = 1;
		} else if (transform.position.x > target.transform.position.x) {
			horInput = -1;
		} else if (transform.position.x == target.transform.position.x) {
			horInput = 0;
		}
	}

	// ==============================
	void FixedUpdate () {

		movement = rb.velocity;
		movement.x = horInput * velocidad;
		movement.y = 1f;
		rb.velocity = movement;
	}
}
