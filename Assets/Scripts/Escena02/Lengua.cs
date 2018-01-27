 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lengua : MonoBehaviour
{
    private Vector3 screenMousePosition;
	private Vector2 launchVector;
    public GameObject lengua;
    public GameObject finLengua;
    public Vector3 posLengua;
    // 0 cerrado, 1 izq
    public Sprite[] sprites;

    public IEnumerator MostrarLengua(float t)
    {
        DibujarLengua();
        lengua.GetComponent<SpriteRenderer>().enabled = true;
        finLengua.GetComponent<SpriteRenderer>().enabled = true;
        // TODO calcular collision
        yield return new WaitForSeconds(t);
        lengua.GetComponent<SpriteRenderer>().enabled = false;
        finLengua.GetComponent<SpriteRenderer>().enabled = false;
        finLengua.transform.position = new Vector2(-100, -100);
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

	public void DibujarLengua()
	{
		screenMousePosition = new Vector2(Input.mousePosition.x / Screen.width * 9, Input.mousePosition.y / Screen.height * 16);
		launchVector = screenMousePosition - transform.position;
		float atan = Mathf.Atan2(launchVector.y, launchVector.x);
		float angle = atan / Mathf.PI * 180.0f;
        
        
        lengua.transform.rotation = Quaternion.Euler(new Vector3( 0, 0, angle + 270));
        finLengua.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));
        lengua.transform.localScale = new Vector3(1.0f, 1.0f * launchVector.magnitude / 7.31f);
        if (Mathf.Abs(angle) > 90.0f)
        {
            transform.localScale = new Vector3(1, 1, 0);
            lengua.transform.position = transform.position + posLengua;
            finLengua.transform.position = screenMousePosition + posLengua;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 0);
            lengua.transform.position = transform.position + new Vector3(-posLengua.x, posLengua.y);
            finLengua.transform.position = screenMousePosition + new Vector3(-posLengua.x, posLengua.y);
        }
        
	}

    private void Update()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            StartCoroutine(MostrarLengua(.5f));
        }
    }
}
