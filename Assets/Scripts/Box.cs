using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Box : MonoBehaviour
{
    Collider2D collander;
    Rigidbody2D rb;
    float addVelX = 0;
    void Awake()
    {
        collander = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = new Vector2(addVelX, rb.velocity.y);
    }
    public void SetVelocity(float velX)
    {
        addVelX = velX;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
            collision.GetComponent<Button>().PlayerEnter();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
            collision.GetComponent<Button>().PlayerExit();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.position.y > transform.position.y + collander.bounds.size.y / 2)
        {
            collision.gameObject.GetComponent<PlayerMovement>().onPlayer = true;
            collision.gameObject.GetComponent<PlayerMovement>().SetVelocity(rb.velocity.x);
        }
        else if (collision.gameObject.CompareTag("Player") && collision.transform.position.y < transform.position.y + collander.bounds.size.y / 2)
        {
            collision.gameObject.GetComponent<PlayerMovement>().onPlayer = false;
            collision.gameObject.GetComponent<PlayerMovement>().SetVelocity(0);
        }
        if (collision.gameObject.CompareTag("PushBlock") && collision.transform.position.y > transform.position.y + collander.bounds.size.y / 2)
        {
            Box boxScript = collision.gameObject.GetComponent<Box>();
            boxScript.SetVelocity(rb.velocity.x);
        }
        if (collision.gameObject.CompareTag("Corpse") && collision.transform.position.y > transform.position.y + collander.bounds.size.y / 2)
        {
            Corpse corpseScript = collision.gameObject.GetComponent<Corpse>();
            corpseScript.SetVelocity(rb.velocity.x);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D collRb = collision.gameObject.GetComponent<Rigidbody2D>();
            collRb.mass = 1f;
            collision.gameObject.GetComponent<PlayerMovement>().onPlayer = false;
        }
        if (collision.gameObject.CompareTag("Corpse"))
        {
            Corpse corpseScript = collision.gameObject.GetComponent<Corpse>();
            corpseScript.SetVelocity(0);
        }
        if (collision.gameObject.CompareTag("PushBlock"))
        {
            Box boxScript = collision.gameObject.GetComponent<Box>();
            boxScript.SetVelocity(0);
        }
    }
}
