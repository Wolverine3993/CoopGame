using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject[] targetLaser;
    Laser laser;
    int players = 0;
    [SerializeField] Sprite pressed, notPressed;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (players == 0)
        {
            foreach(GameObject gameObject in targetLaser)
            {
                laser = gameObject.GetComponent<Laser>();
                laser.ChangeState(true);
            }
            spriteRenderer.sprite = notPressed;
        }
        else
        {
            foreach (GameObject gameObject in targetLaser)
            {
                laser = gameObject.GetComponent<Laser>();
                laser.ChangeState(false);
            }
            spriteRenderer.sprite = pressed;
        }
    }
    public void PlayerEnter()
    {
        players++;
    }
    public void PlayerExit()
    {
        players--;
    }
}
