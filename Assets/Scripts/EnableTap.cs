using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTap : MonoBehaviour
{
    public void ActivateTap()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
