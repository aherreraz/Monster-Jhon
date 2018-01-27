using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private BarScript bar;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float curVal;

    public float MaxVal
    {
        get { return maxVal; }
        set { maxVal = value; bar.MaxVal = value; }
    }
    public float Value
    {
        get { return curVal; }
        set { curVal = Mathf.Min(value, maxVal); bar.Value = value; }
    }
    public BarScript Bar
    {
        get { return bar; }
        set { bar = value; }
    }
    public void Initialize()
    {
        bar.Initialize();
        Value = curVal;
        MaxVal = maxVal;
    }
}