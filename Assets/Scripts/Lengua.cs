 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lengua : MonoBehaviour
{
    private Vector3 screenMousePosition;
	private Vector2 launchVector;
	public GameObject lengua;
    
    public IEnumerator MostrarLengua(float t)
    {
        DibujarLengua();
        lengua.GetComponent<SpriteRenderer>().enabled = true;
        // TODO calcular collision
        yield return new WaitForSeconds(t);
        lengua.GetComponent<SpriteRenderer>().enabled = false;
    }

	public void DibujarLengua()
	{
		screenMousePosition = new Vector2(Input.mousePosition.x / Screen.width * 16, Input.mousePosition.y / Screen.height * 9);
		Vector3[] positions = { transform.position, screenMousePosition };
		launchVector = screenMousePosition - transform.position;
        print(launchVector);
		float atan = Mathf.Atan2(launchVector.y, launchVector.x);
		float angle = atan / Mathf.PI * 180.0f;
		lengua.transform.rotation = Quaternion.Euler(new Vector3( 0, 0, angle + 270));
		lengua.transform.position = transform.position;
		lengua.transform.localScale = new Vector3(1.0f, 1.0f * launchVector.magnitude);
	}

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            print("click");
            StartCoroutine(MostrarLengua(.5f));
        }
    }
}
