using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{

    public float LevelTimer = 0.0f;
    public float HighScore = 0.0f;

    string path = Application.dataPath + "/testSave.json";

    public void SetHighScore()
    {
        Load();
        if (LevelTimer > HighScore)
        {
            HighScore = LevelTimer;
            Save();
        }

    }

    public void ResetLevelTime()
    {
        LevelTimer = 0.0f;
    }

    public void Save()
    {
        SaveData sd = new SaveData();
        sd.highscore = HighScore;
        string jsonText = JsonUtility.ToJson(sd);
        File.WriteAllText(path, jsonText);
    }

    public void Load()
    {
        if (!File.Exists(path))
        {
            return;
        }
        string saveText = File.ReadAllText(path);
        SaveData myData = JsonUtility.FromJson<SaveData>(saveText);
        HighScore = myData.highscore;
    }
}

public class SaveData
{
    public float highscore;
}