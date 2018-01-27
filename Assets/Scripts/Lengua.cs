using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lengua : MonoBehaviour {

	private Vector3 screenMousePosition;
	private Vector2 launchVector;
	public GameObject lengua;

	public void ResetValues()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GetComponent<LineRenderer>().SetPosition(0, Vector3.zero);
		GetComponent<LineRenderer>().SetPosition(1, Vector3.zero);
	}

	public void Launch (Vector2 launchDirection)
	{
		GetComponent<Rigidbody2D>().velocity = launchDirection;
	}


	public void DrawLaunchVector()
	{
		screenMousePosition = new Vector2(Input.mousePosition.x / Screen.width * 16, Input.mousePosition.y / Screen.height * 9);
		Vector3[] positions = { transform.position, screenMousePosition };
		launchVector = screenMousePosition - transform.position;
		//print(Mathf.Atan2(launchVector.y, launchVector.x));
		float atan = Mathf.Atan2(launchVector.y, launchVector.x);
		float angle = atan / Mathf.PI * 180.0f;
		print(angle);
		lengua.transform.rotation = Quaternion.Euler(new Vector3( 0, 0, (angle + 270)));
		//GetComponent<LineRenderer>().SetPositions(positions);
		lengua.transform.position = transform.position;
		lengua.transform.localScale = new Vector3(1.0f, 1.0f * launchVector.magnitude);
		//
		//
	}
	public void ToggleLaunchVector()
	{
		GetComponent<LineRenderer>().enabled = !GetComponent<LineRenderer>().enabled;
	}
	public Vector2 GetLaunchDirection()
	{
		return launchVector.normalized;
	}
	public float GetLaunchStrength()
	{
		return launchVector.magnitude;
	}
}
