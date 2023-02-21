using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] List<string> scenes = new List<string>();
    int currentScene = 0;
    int levelsUnlocked = 1;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if(scenes[currentScene] != SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene(sceneName: scenes[currentScene]);
        }
        if(currentScene > levelsUnlocked)
            levelsUnlocked = currentScene;
    }
    public void ChangeScene(int scene)
    {
        currentScene = scene;
    }
    public void LoadTitle()
    {
        currentScene = 0;
    }
    public void Continue()
    {
        currentScene = levelsUnlocked;
    }
}
