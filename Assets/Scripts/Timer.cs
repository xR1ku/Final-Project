using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    [SerializeField] PlayerStats score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = "Survived: " + Mathf.RoundToInt(score.LevelTimer);
        score.LevelTimer += Time.deltaTime;
    }
}
