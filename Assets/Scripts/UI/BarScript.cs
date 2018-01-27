using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    private float maxVal;
    private float curVal;
    private Image content;

    public float MaxVal
    {
        get { return maxVal; }
        set { maxVal = value; }
    }
    public float Value
    {
        get { return curVal; }
        set { curVal = value; content.fillAmount = value / maxVal; }
    }
    public void Initialize()
    {
        content = transform.GetChild(0).GetComponent<Image>();
    }
}
