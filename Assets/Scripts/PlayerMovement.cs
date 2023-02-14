using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpHeight;
    enum PlayerNumber
    {
        Player1,
        Player2
    };
    [SerializeField] PlayerNumber playerNumber = new PlayerNumber();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerNumber.ToString());
    }
    void Player1Move() 
    { 
    
    }
}
