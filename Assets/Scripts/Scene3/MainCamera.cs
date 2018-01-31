using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public float offset;
	GameObject player;

	// ==================================
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// ==================================
	void Update () {

		transform.position = new Vector3 (transform.position.x, player.transform.position.y + offset, transform.position.z);
	}
}
