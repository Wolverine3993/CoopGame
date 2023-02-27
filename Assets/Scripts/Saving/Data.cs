using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data 
{
    public int levelsUnlocked;
    public Data(GameManagerScript gameManagerScript)
    {
        levelsUnlocked = gameManagerScript.levelsUnlocked;
    }
}
