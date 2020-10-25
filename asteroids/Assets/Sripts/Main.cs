using UnityEngine;
using System.Collections.Generic;
using Sripts;


public class Main : MonoBehaviour
{
    private GameLevel currentLevel = GameLevel.First;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentLevel == GameLevel.First)
            {
                currentLevel = GameLevel.Second;
            }
            else if (currentLevel == GameLevel.Second)
            {
                currentLevel = GameLevel.Third;
            }
            else
            {
                currentLevel = GameLevel.First;
            }
        }
    }

    #region Properties

    public GameLevel CurrentLevel
    {
        get => currentLevel;
        set => currentLevel = value;
    }

    #endregion
}