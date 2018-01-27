using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paloma : MonoBehaviour
{
    public float velocidad;
    private Vector2 movimiento;

    void Start ()
    {
        movimiento.x = Random.Range(-1.0f, 1.0f);
        movimiento.y = Random.Range(-1.0f, 1.0f);
    }
	
	void Update ()
    {
        transform.Translate(movimiento * velocidad * Time.deltaTime);
    }
}
