using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mosca>())
        {
            // TODO anotar punto
            print("+1 punto");
            Destroy(collision.gameObject);
        }
    }
}
