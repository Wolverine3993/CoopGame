using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    Collider2D collander;
    Rigidbody2D rb;
    [SerializeField] KeyCode respawn;
    Vector2 respawnChoords;
    bool touchedGround = false;
    bool go = false;
    float addVelX = 0;
    enum Player
    {
        Player1,
        Player2
    }
    [SerializeField] Player playerVal;
    void Awake()
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
            if(touchedGround)
                rb.velocity = new Vector2(addVelX, rb.velocity.y);
        }
    }
    public void OnInitiate(Vector2 move)
    {
        go = true;
        rb.velocity = move;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        touchedGround = true;
    }
}
