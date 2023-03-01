using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameObject mainScreen, levelSelect, settings;
    GameObject currentScreen;
    [SerializeField] GameObject cameraTarget;
    [SerializeField] float speed;
    Vector2 target = new Vector2(0, 0);
    void Start()
    {
        currentScreen = mainScreen;
    }
    void Update()
    {
        currentScreen.SetActive(true);
        cameraTarget.transform.position = Vector2.MoveTowards(cameraTarget.transform.position, target, speed);
    }
    public void EnableSelect()
    {
        currentScreen = levelSelect;
        mainScreen.SetActive(false);
    }
    public void Back()
    {
        currentScreen.SetActive(false);
        currentScreen = mainScreen;
    }
    public void NextCamera()
    {
        target += new Vector2(17.82f, 0);
    }
    public void BackCamera()
    {
        target -= new Vector2(17.82f, 0);
    }
}
