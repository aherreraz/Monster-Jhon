using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public bool pulsado;
    
	public void OnPointerDown (PointerEventData evenData)
    {
		pulsado = true;
	}
	public void OnPointerUp (PointerEventData evenData)
    {
		pulsado = false;
	}
}
