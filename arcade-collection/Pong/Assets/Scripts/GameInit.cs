using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    private void Awake()
    {
        Stuff.Init();
        // Screen.SetResolution(Screen.width, (int) Screen.height, true);
    }

    private void Start()
    {
        // Screen.SetResolution(Screen.width, Screen.height, true);
    }
}