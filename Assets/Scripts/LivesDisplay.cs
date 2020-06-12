using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] Sprite[] heartSpriteArray = default;
    int heartSpriteIndex = default;
    int lives = default;
    float difficulty = default;

    public void Start()
    {
        SetHeartSpriteIndex();
        SetLivesSprite();
    }

    private void SetHeartSpriteIndex()
    {
        difficulty = PlayerPrefsController.GetDifficulty();
        
        if (difficulty == 2)
        {
            heartSpriteIndex = (int)difficulty - 2;
            lives = 3;
        }
        else if (difficulty == 1)
        {
            heartSpriteIndex = (int)difficulty + 3;
            lives = 5;
        }
        else if (difficulty == 0)
        {
            heartSpriteIndex = (int)difficulty +10;
            lives = 10;
        }
        else
        {
            Debug.LogError("Difficulty setting out of range");
        }
    }

    public void TakeLife()
    {
        lives--;
        heartSpriteIndex++;
        if (lives <= 0)
        {
            SetLivesSprite();
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
        else
        {
            SetLivesSprite();
        }
    }

     private void SetLivesSprite()
    {
        GetComponent<SpriteRenderer>().sprite = heartSpriteArray[heartSpriteIndex];
    }
}
