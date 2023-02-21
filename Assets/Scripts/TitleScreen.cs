using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameObject mainScreen, levelSelect, settings;
    GameObject currentScreen;
    void Start()
    {
        currentScreen = mainScreen;
    }
    void Update()
    {
        currentScreen.SetActive(true);
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
}
