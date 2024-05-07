using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    COREGAMEPLAY,
    ENVIRONMENT,
    GAMEOVER,
    MAINMENU
}

public class SceneController : MonoBehaviour
{

    List<string> sceneList = new List<string>
    { "CoreGamePlay", "Environment", "GameOver", "MainMenu" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == sceneList[(int)Scenes.COREGAMEPLAY])
        {
            AddScene(sceneList[(int)Scenes.ENVIRONMENT]);
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
}
