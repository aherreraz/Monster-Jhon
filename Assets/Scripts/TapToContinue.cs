using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToContinue : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            LevelManager.instance.LoadNextLevel();
    }
}
