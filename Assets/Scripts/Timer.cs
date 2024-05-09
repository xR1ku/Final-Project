using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    //Serialized fields
    [SerializeField] TMP_Text timer;
    [SerializeField] PlayerStats score;
    [SerializeField] float maxSpawnRate;
    [SerializeField] float minSpawnRate;
    [SerializeField] float spawnTime;
    
    //Public fields
    public UnityEvent spawn;

    //private fields
    float spawnTimer;
    GameObject enemySpawner;
    EnemySpawner mySpawner;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer.text = "Survived: " + Mathf.RoundToInt(score.LevelTimer);
        score.LevelTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnTime) 
        {
            spawn.Invoke();
            spawnTime = Random.Range(minSpawnRate, maxSpawnRate);
            spawnTimer = 0.0f;
        }
    }
}
