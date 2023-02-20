using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OneWayWall : MonoBehaviour
{
    enum Direction
    {
        Up, 
        Down,
        Left,
        Right
    }
    [SerializeField] Direction dir;
    delegate bool Skibbity();
    Skibbity GetInput;
    void Start()
    {
        switch (dir.ToString()) {
            case "Up": 
                { 
                    GetInput = Up; 
                    break; 
                }
            case "Down":
                {
                    GetInput = Down;
                    break;
                }
            case "Left":
                {
                    GetInput = Left;
                    break;
                }
            case "Right":
                {
                    GetInput = Right;
                    break;
                }
        }
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        Debug.Log("hit");
    }
    private bool Up()
    {
        if (Input.GetAxisRaw("Vertical") == 1)
            return true;
        return false;
    }
    private bool Down()
    {
        if (Input.GetAxisRaw("Vertical") == -1)
            return true;
        return false;
    }
    private bool Left()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
            return true;
        return false;
    }
    private bool Right()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
            return true;
        return false;
    }
}
