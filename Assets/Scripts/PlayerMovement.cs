using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] LayerMask groundLayer;
    float xInput;
    float yInput;
    Rigidbody2D rb;
    Collider2D collander;
    private delegate void HandleMove();
    HandleMove Move;
    enum PlayerNumber
    {
        Player1,
        Player2
    };
    [SerializeField] PlayerNumber playerNumber = new PlayerNumber();
    void Start()
    {
        Move = Player1Move;
        if (playerNumber.ToString() == "Player2")
        {
            Move = Player2Move;
            groundLayer += LayerMask.GetMask("Player1");
        }
        else
            groundLayer += LayerMask.GetMask("Player2");
        rb = GetComponent<Rigidbody2D>();
        collander = GetComponent<Collider2D>();
        
    }
    void Update()
    {
        Move();
        if(TouchingGround() && yInput > 0)
            Jump();
    }
    void Player1Move() 
    {
        xInput = Input.GetAxisRaw("Player1Horizontal");
        yInput = Input.GetAxisRaw("Player1Vertical");
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }
    void Player2Move()
    {
        xInput = Input.GetAxisRaw("Player2Horizontal");
        yInput = Input.GetAxisRaw("Player2Vertical");
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
    bool TouchingGround()
    {
        return Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - collander.bounds.size.y / 2), new Vector2(collander.bounds.size.x - 0.1f, 0.1f), 0, Vector2.down, 0.1f, groundLayer) != false;        
    }
}
