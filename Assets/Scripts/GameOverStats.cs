using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverStats : MonoBehaviour
{
    [SerializeField] TMP_Text stats;
    [SerializeField] TMP_Text highScore;
    [SerializeField] PlayerStats score;

    // Start is called before the first frame update
    void Start()
    {
        stats.text = "You survived for " + Mathf.RoundToInt(score.LevelTimer) + " seconds!";
        highScore.text = "Current high score: " + Mathf.RoundToInt(score.HighScore) + " seconds";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
