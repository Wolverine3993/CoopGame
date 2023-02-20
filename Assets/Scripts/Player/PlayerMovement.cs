using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float slowMoveSpeed;
    float _moveSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] LayerMask groundLayer;
    float xInput;
    float yInput;
    public bool onPlayer = false;
    Rigidbody2D rb;
    Collider2D collander;
    bool canJump = true;
    float addVelocityX;
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
        _moveSpeed = moveSpeed;
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
        if(TouchingGround() && yInput > 0 && canJump)
            Jump();
    }
    void Player1Move()
    {
        xInput = Input.GetAxisRaw("Player1Horizontal");
        yInput = Input.GetAxisRaw("Player1Vertical");
        if (!onPlayer)
        {
            rb.velocity = new Vector2(xInput * _moveSpeed, rb.velocity.y);
            return;
        }
        rb.velocity = new Vector2(xInput * _moveSpeed + addVelocityX, rb.velocity.y);
    }
    void Player2Move()
    {
        xInput = Input.GetAxisRaw("Player2Horizontal");
        yInput = Input.GetAxisRaw("Player2Vertical");
        if (!onPlayer)
        {
            rb.velocity = new Vector2(xInput * _moveSpeed, rb.velocity.y);
            return;
        }
        rb.velocity = new Vector2(xInput * _moveSpeed + addVelocityX, rb.velocity.y);
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
    bool TouchingGround()
    {
        return Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - collander.bounds.size.y / 2), new Vector2(collander.bounds.size.x - 0.1f, 0.1f), 0, Vector2.down, 0.1f, groundLayer) != false;        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.position.y > transform.position.y + collander.bounds.size.y / 2) 
        {
            Rigidbody2D collRb = collision.gameObject.GetComponent<Rigidbody2D>();
            collRb.mass = 0.00001f;
            _moveSpeed = slowMoveSpeed;
            collision.gameObject.GetComponent<PlayerMovement>().onPlayer = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.position.y < transform.position.y + collander.bounds.size.y / 2)
        {
            Rigidbody2D collRb = collision.gameObject.GetComponent<Rigidbody2D>();
            collRb.mass = 1f;
            _moveSpeed = moveSpeed;
            collision.gameObject.GetComponent<PlayerMovement>().onPlayer = false;
        }
        else if(collision.gameObject.CompareTag("Player") && collision.transform.position.y > transform.position.y + collander.bounds.size.y / 2)
        {
            collision.gameObject.GetComponent<PlayerMovement>().onPlayer = true;
            collision.gameObject.GetComponent<PlayerMovement>().SetVelocity(rb.velocity.x);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D collRb = collision.gameObject.GetComponent<Rigidbody2D>();
            collRb.mass = 1f;
            _moveSpeed = moveSpeed;
            collision.gameObject.GetComponent<PlayerMovement>().onPlayer = false;
        }
    }
    public void SetVelocity(float objectVelX)
    {
        addVelocityX = objectVelX;
    }
}