﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            LevelManager.instance.LoadNextLevel();
    }
}
