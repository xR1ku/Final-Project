using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Create an enum to refer to scenes in the game
public enum Scenes
{
    COREGAMEPLAY,
    ENVIRONMENT,
    GAMEOVER,
    MAINMENU,
    AUDIO
}

public class SceneController : MonoBehaviour
{
    //Create a list to hold the string values of levels
    List<string> sceneList = new List<string>
    { "CoreGamePlay", "Environment", "GameOver", "MainMenu", "Audio" };

    void OnEnable()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == sceneList[(int)Scenes.COREGAMEPLAY])
        {
            AddScene(sceneList[(int)Scenes.ENVIRONMENT]);
            AddScene(sceneList[(int)Scenes.AUDIO]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void AddScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }

    void RemoveScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }

    public void OnPlayerDeath()
    {
        SceneManager.LoadScene(sceneList[(int)Scenes.GAMEOVER]);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
