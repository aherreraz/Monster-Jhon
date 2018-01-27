using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObstaculos : MonoBehaviour {

	public float minTime;
	public float maxTime;
	public GameObject [] obstaculos;

	int values;
	float xvalue;

	// ==============================
	void Start () {

		StartCoroutine (Generate ());
	}

	// ==============================
	void Update () {

		values = Random.Range (0, 3);

		if (values == 0) {
			xvalue = Vector2.right.x * -2f;
		} else if (values == 1) {
			xvalue = 0f;
		} else {
			xvalue = Vector2.right.x * 2f;
		}
	}

	// ==============================
	public IEnumerator Generate () {

		yield return new WaitForSeconds (0.1f);
		while (true) {
			Instantiate (obstaculos [Random.Range (0, obstaculos.Length)], new Vector2 (xvalue, transform.position.y), Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (minTime, maxTime));
		}
	}
}
