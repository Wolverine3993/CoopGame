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
        if(Input.GetKey(KeyCode.Escape) && currentScene != 0)
            LoadTitle();
        if(scenes[currentScene] != SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene(sceneName: scenes[currentScene]);
        }
        if(currentScene > levelsUnlocked)
            levelsUnlocked = currentScene;
    }
    public void NextLevel()
    {
        currentScene += 1;
    }
    public void LoadTitle()
    {
        currentScene = 0;
    }
    public void Continue()
    {
        currentScene = levelsUnlocked;
    }
    public void Restart()
    {
        SceneManager.LoadScene(sceneName: scenes[currentScene]);
    }
    public void LoadLevel(int scene)
    {
        currentScene = scene;
    }
}
