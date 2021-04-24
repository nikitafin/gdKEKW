using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public GameObject go;


    private void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.touches[i].position.x < Stuff.ScreenWidth * 0.25)
            {
                if (Input.touches[i].phase == TouchPhase.Moved)
                {
                    var temp = go.transform.position;
                    Debug.Log(Input.touches[i].deltaPosition.ToString());
                    if (Input.touches[i].deltaPosition.y > 0f)
                    {
                        temp.y += 10f * Time.deltaTime;
                    }

                    if (Input.touches[i].deltaPosition.y < 0f)
                    {
                        temp.y -= 10f * Time.deltaTime;
                    }

                    go.transform.position = temp;
                }
            }
        }
    }
}