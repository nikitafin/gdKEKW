using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosUtils : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("GizmosUtils setup");
    }

    private void FixedUpdate()
    {
        Debug.DrawLine(new Vector3(-Stuff.CameraWidth * 0.5f, Stuff.CameraHeight, 0f),
            new Vector3(-Stuff.CameraWidth * 0.5f, -Stuff.CameraHeight, 0f), Color.red);

        Debug.DrawLine(new Vector3(Stuff.CameraWidth * 0.5f, Stuff.CameraHeight, 0f),
            new Vector3(Stuff.CameraWidth * 0.5f, -Stuff.CameraHeight, 0f), Color.green);
    }
}