using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] List<string> scenes = new List<string>();
    int currentScene = 0;
    public int levelsUnlocked { get; private set; } = 1;
    bool canRestart = true;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
            if (Input.GetKey(KeyCode.Escape) && currentScene != 0)
                LoadTitle();
            if (Input.GetKey(KeyCode.R) && canRestart && currentScene != 0)
                Restart();
            if (scenes[currentScene] != SceneManager.GetActiveScene().name)
            {
                SceneManager.LoadScene(sceneName: scenes[currentScene]);
            }
            if (currentScene > levelsUnlocked)
                levelsUnlocked = currentScene;
    }
    public void Save()
    {
        Saving.SaveLevel(this);
    }
    public void Load()
    {
        Data data = Saving.LoadUnlocked();
        levelsUnlocked = data.levelsUnlocked;
    }
    public void DeleteSave()
    {
        Saving.DeleteSave();
    }
    public void LoadTitle()
    {
        currentScene = 0;
    }
    public void NextLevel()
    {
        currentScene += 1;
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
    public void CanRestart(bool state)
    {
        canRestart = state;
    }
}
