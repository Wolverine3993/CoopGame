using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    Collider2D collander;
    Rigidbody2D rb;
    [SerializeField] KeyCode respawn;
    Vector2 respawnChoords;
    bool go = false;
    enum Player
    {
        Player1,
        Player2
    }
    [SerializeField] Player playerVal;
    void Start()
    {
        respawnChoords = GameObject.Find("Respawn").GetComponent<Respawn>().GetRespawn(playerVal.ToString());
        collander = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (go)
        {
            if (Input.GetKey(respawn)) 
            { 
                GameObject clone = GameObject.Instantiate(playerPrefab, respawnChoords, Quaternion.Euler(0,0,0));
                Destroy(this.gameObject);
            }
        }
    }
    public void OnInitiate(float xMove)
    {
        go = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.position.y > transform.position.y + collander.bounds.size.y / 2)
        {
            Rigidbody2D collRb = collision.gameObject.GetComponent<Rigidbody2D>();
            collRb.mass = 0.00001f;
            collision.gameObject.GetComponent<PlayerMovement>().onPlayer = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.position.y < transform.position.y + collander.bounds.size.y / 2)
        {
            Rigidbody2D collRb = collision.gameObject.GetComponent<Rigidbody2D>();
            collRb.mass = 1f;
            collision.gameObject.GetComponent<PlayerMovement>().onPlayer = false;
        }
        else if (collision.gameObject.CompareTag("Player") && collision.transform.position.y > transform.position.y + collander.bounds.size.y / 2)
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
            collision.gameObject.GetComponent<PlayerMovement>().onPlayer = false;
        }
    }
}
