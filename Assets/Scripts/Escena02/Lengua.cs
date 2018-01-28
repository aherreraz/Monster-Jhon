 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lengua : MonoBehaviour
{
    private Vector3 screenMousePosition;
	private Vector3 launchVector;
    public GameObject lengua;
    public GameObject finLengua;
    public Vector3 posLengua;
    // 0 cerrado, 1 izq
    public Sprite[] sprites;

    public void HabilitarLengua()
    {
        lengua.GetComponent<SpriteRenderer>().enabled = true;
        finLengua.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void DeshabilitarLengua()
    {
        lengua.GetComponent<SpriteRenderer>().enabled = false;
        finLengua.GetComponent<SpriteRenderer>().enabled = false;
        finLengua.transform.position = new Vector2(-100, -100);
    }

	public void DibujarLengua()
	{
		screenMousePosition = new Vector2(Input.mousePosition.x / Screen.width * 9, Input.mousePosition.y / Screen.height * 16);
		launchVector = screenMousePosition - transform.GetChild(0).position - posLengua;
		float atan = Mathf.Atan2(launchVector.y, launchVector.x);
		float angle = atan / Mathf.PI * 180.0f;
        
        
        lengua.transform.rotation = Quaternion.Euler(new Vector3( 0, 0, angle + 270));
        finLengua.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));
        lengua.transform.localScale = new Vector3(1.0f, 1.0f * launchVector.magnitude / 7.31f);
        if (Mathf.Abs(angle) > 90.0f)
        {
            transform.GetChild(0).localScale = new Vector3(1, 1, 0);
            lengua.transform.position = transform.GetChild(0).position + posLengua;
            finLengua.transform.position = transform.GetChild(0).position + posLengua + launchVector;
        }
        else
        {
            transform.GetChild(0).localScale = new Vector3(-1, 1, 0);
            lengua.transform.position = transform.GetChild(0).position + new Vector3(-posLengua.x, posLengua.y);
            finLengua.transform.position = transform.GetChild(0).position + launchVector + new Vector3(-posLengua.x, posLengua.y);
        }
	}

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetTrigger("Eat");
        }
    }
}
