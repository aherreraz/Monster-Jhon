using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Air : MonoBehaviour
{
	public float speed;
	public float tMin, tMax;
	private Vector2 movement;

	private void Start()
	{
		StartCoroutine(ChangeDirection());
	}
	private void Update()
	{
		transform.Translate(movement * speed * Time.deltaTime);
	}
	private IEnumerator ChangeDirection()
	{
		while (true)
		{
			movement.x = Random.Range(-1.0f, 1.0f);
			movement.y = Random.Range(-1.0f, 1.0f);
			yield return new WaitForSeconds(Random.Range(tMin, tMax));
		}
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
