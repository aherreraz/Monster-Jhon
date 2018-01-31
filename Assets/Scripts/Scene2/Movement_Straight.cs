using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Straight : MonoBehaviour
{
	public float speed;
	private Vector2 movement;

	private void Start()
	{
		movement.x = Random.Range(-1.0f, 1.0f);
		movement.y = Random.Range(-1.0f, 1.0f);
	}

	private void Update()
	{
		transform.Translate(movement * speed * Time.deltaTime);
	}

	public void DisableMovement()
	{
		this.enabled = false;
	}
	public void DestroyObject()
	{
		Destroy(gameObject);
	}
}
