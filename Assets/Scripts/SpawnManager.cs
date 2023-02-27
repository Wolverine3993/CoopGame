using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    GameManagerScript gameManagerScript;
    void Start()
    {
        GameObject foundObject = GameObject.Find("GameManager(Clone)");
        if (foundObject == null)
            gameManagerScript = GameObject.Instantiate(gameManager).GetComponent<GameManagerScript>();
        else
            gameManagerScript = foundObject.GetComponent<GameManagerScript>();
    }
    public void LoadLevel(int scene)
    {
        gameManagerScript.LoadLevel(scene);
    }
    public void Continue()
    {
        gameManagerScript.Continue();
    }
    public void LoadData()
    {
        gameManagerScript.Load();
    }
    public void Save()
    {
        gameManagerScript.Save();
    }
    public void DeleteSave()
    {
        gameManagerScript.DeleteSave();
    }
}
