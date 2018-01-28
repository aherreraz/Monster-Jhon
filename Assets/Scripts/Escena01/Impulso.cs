using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Impulso : MonoBehaviour {

	public ButtonUI btnLeft;
	public ButtonUI btnRight;
	public GameObject burbujas;
	public float velocidad;
	public float fuerza;

	float direccion;
	Rigidbody2D rb;
	Animator anim;
	Vector2 movimiento;
    
	private void Start ()
    {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		movimiento = new Vector2 ();
	}
	private void Update ()
    {
		if (GameManager.enJuego == true)
        {
			movimiento = rb.velocity;

			if (btnLeft.pulsado)
            {
				direccion = -1;
				movimiento.y = fuerza;
				anim.SetBool ("Nado", true);
				transform.GetChild(0).gameObject.SetActive (true);
				rb.AddForce (new Vector2 (0, -fuerza), ForceMode2D.Impulse);
			}
            else if (btnRight.pulsado)
            {
				direccion = 1;
				movimiento.y = fuerza;
				anim.SetBool ("Nado", true);
                transform.GetChild(0).gameObject.SetActive (true);
				rb.AddForce (new Vector2 (0, -fuerza), ForceMode2D.Impulse);
			}
            else
            {
				direccion = Input.GetAxis ("Horizontal");
				anim.SetBool ("Nado", false);
			}

			movimiento.x = direccion * 10f;
			rb.velocity = movimiento;

			if (GameManager.tiempo <= 0)
            {
                Explotar();
                GameManager.tiempo = 5;
                LevelManager.instance.ReloadLevelWithDelay(0.7f);
			}
		}
	}
    
	public void OnTriggerEnter2D (Collider2D col )
    {
		if (col.tag == "Fin")
        {
			GameManager.enJuego = false;
            LevelManager.instance.LoadNextLevel();
		}
	}
    
	public void OnCollisionEnter2D (Collision2D col)
    {
		if (col.gameObject.tag == "Enemy")
        {
            Explotar();
            LevelManager.instance.ReloadLevelWithDelay(0.7f);
        }
	}

    private void Explotar()
    {
        GameManager.enJuego = false;
        rb.gravityScale = 0;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<Animator>().SetTrigger("Die");
    }
}
