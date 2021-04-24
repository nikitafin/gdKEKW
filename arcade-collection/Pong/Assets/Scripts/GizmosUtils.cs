using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosUtils : MonoBehaviour
{
    private float ScreenWidth { get; set; }

    private void Awake()
    {
        ScreenWidth = Screen.width;
    }

    private void FixedUpdate()
    {
        Debug.DrawLine(new Vector3(-1F, 1F) * (ScreenWidth * 0.25F), 
            new Vector3(-1F,-1F) * (ScreenWidth * 0.25F),
            Color.red);
    }
}