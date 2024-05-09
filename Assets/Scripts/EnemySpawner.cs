using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] GameObject prefabEnemy;

    //Private fields
    GameObject timerCanvas;
    Timer timer;
    Vector3 spawnPos;

    private void Start()
    {
        timerCanvas = GameObject.Find("TimerCanvas");
        if (timerCanvas != null)
        {
            timer = timerCanvas.GetComponent<Timer>();
            if (timer != null)
            {
                timer.spawn.AddListener(SpawnEnemy);
            }

        }
    }


    //Public Function for event invocation
    public void SpawnEnemy()
    {
        spawnPos = new Vector3(9.0f, Random.Range(-3.0f, 10.0f), 0);
        Instantiate(prefabEnemy, spawnPos, Quaternion.identity, this.transform);
    }
}
