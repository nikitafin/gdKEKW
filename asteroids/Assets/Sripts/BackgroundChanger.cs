using System;
using System.Collections.Generic;
using Sripts;
using UnityEngine;
using UnityEngine.Serialization;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] public Sprite[] backgroundSprites;

    private Dictionary<GameLevel, Sprite> levelToBackground = new Dictionary<GameLevel, Sprite>();
    private GameLevel currentLevel;

    private SpriteRenderer spriteRenderer;

    private GameObject mainObject;
    private Main mainScript;

    private void Start()
    {
        int levelsCount = 0;
        foreach (GameLevel level in Enum.GetValues(typeof(GameLevel)))
        {
            if (levelsCount > backgroundSprites.Length)
            {
                levelsCount = 0;
            }

            levelToBackground.Add(level, backgroundSprites[levelsCount]);
            ++levelsCount;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();

        mainObject = GameObject.Find("Main");
        mainScript = mainObject.GetComponent<Main>();
    }

    private void Update()
    {
        if (currentLevel != mainScript.CurrentLevel)
        {
            currentLevel = mainScript.CurrentLevel;
            spriteRenderer.sprite = levelToBackground[currentLevel];
        }
    }
}