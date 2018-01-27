using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mosca>())
        {
            // TODO anotar punto
            print("+1 punto");
            collision.GetComponent<Animator>().SetTrigger("Die");
            collision.GetComponent<Mosca>().enabled = false;
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
