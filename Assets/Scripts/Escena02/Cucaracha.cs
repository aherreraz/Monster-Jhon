using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucaracha : MonoBehaviour
{
    public float velocidad;
    public float tMin, tMax;
    private Vector2 movimiento;
    
    void Start ()
    {
        StartCoroutine(CambiarDireccion());
    }
	
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity += movimiento * velocidad * Time.deltaTime;
    }

    private IEnumerator CambiarDireccion()
    {
        while (true)
        {
            movimiento.x = Random.Range(-1.0f, 1.0f);
            movimiento.y = Random.Range(-1.0f, 1.0f);
            yield return new WaitForSeconds(Random.Range(tMin, tMax));
        }
    }
}
