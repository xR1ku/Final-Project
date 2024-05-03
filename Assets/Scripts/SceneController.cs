using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    COREGAMEPLAY,
    UI
}

public class SceneController : MonoBehaviour
{

    List<string> sceneList = new List<string>
    { "CoreGamePlay", "UI" };

    // Start is called before the first frame update
    void Start()
    {
        AddScene(sceneList[(int)Scenes.UI]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }

    void RemoveScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
}
