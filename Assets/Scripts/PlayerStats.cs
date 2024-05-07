using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{

    public float LevelTimer = 0.0f;
    public float HighScore = 0.0f;

    public void SetHighScore()
    {
        if (HighScore == 0.0f)
            HighScore = LevelTimer;
        else if (LevelTimer > HighScore)
            HighScore = LevelTimer;

    }

    public void ResetLevelTime()
    {
        LevelTimer = 0.0f;
    }
}
