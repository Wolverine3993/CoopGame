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
    bool pauseScreenLoaded = false;
    [SerializeField] Canvas pauseScreen;
    float timer = 0;
    GameObject[] players;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && currentScene != 0 && timer <= 0)
        {
            PauseScreen();
            timer = .5f;
        }
        if (pauseScreenLoaded)
        {
            pauseScreen.worldCamera = Camera.main;
            pauseScreen.gameObject.SetActive(true);
        }
        else
            pauseScreen.gameObject.SetActive(false);
        if (Input.GetKey(KeyCode.R) && canRestart && currentScene != 0 && !pauseScreenLoaded)
            Restart();
        if (scenes[currentScene] != SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene(sceneName: scenes[currentScene]);
        }
        if (currentScene > levelsUnlocked)
            levelsUnlocked = currentScene;
        if (timer > 0)
            timer -= Time.deltaTime;
    }
    public void PauseScreen()
    {
        pauseScreenLoaded = !pauseScreenLoaded;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            if (pauseScreenLoaded)
            {
                foreach (GameObject p in players)
                {
                    p.GetComponent<PlayerMovement>().canMove = false;
                }
            }
            else
            {
                foreach (GameObject p in players)
                {
                    p.GetComponent<PlayerMovement>().canMove = true;
                }
            }
        }
        GameObject[] corpses = GameObject.FindGameObjectsWithTag("Corpse");
        if(corpses != null)
        {
            if (pauseScreenLoaded)
            {
                foreach (GameObject p in corpses)
                    p.GetComponent<Corpse>().canRespawn = false;
            }
            else
            {
                foreach (GameObject p in corpses)
                    p.GetComponent<Corpse>().canRespawn = true;
            }
        }
    }
    public void Save()
    {
        Saving.SaveLevel(this);
    }
    public void Load()
    {
        Data data = Saving.LoadUnlocked();
        if(data != null)
            levelsUnlocked = data.levelsUnlocked;
    }
    public void DeleteSave()
    {
        Saving.DeleteSave();
    }
    public void LoadTitle()
    {
        currentScene = 0;
        pauseScreenLoaded = false;
    }
    public void NextLevel()
    {
        currentScene += 1;
        pauseScreenLoaded = false;
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
