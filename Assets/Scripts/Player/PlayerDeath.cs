using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] GameObject corpse;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            GameObject _corpse = GameObject.Instantiate(corpse, transform.position, Quaternion.Euler(0, 0, 0));
            _corpse.GetComponent<Corpse>().OnInitiate(GetComponent<Rigidbody2D>().velocity);
            Destroy(this.gameObject);
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            GameObject _corpse = GameObject.Instantiate(corpse, transform.position, Quaternion.Euler(0, 0, 0));
            _corpse.GetComponent<Corpse>().OnInitiate(GetComponent<Rigidbody2D>().velocity);
            Destroy(this.gameObject);
        }
    }
    public void Die()
    {
        GameObject _corpse = GameObject.Instantiate(corpse, transform.position, Quaternion.Euler(0, 0, 0));
        _corpse.GetComponent<Corpse>().OnInitiate(GetComponent<Rigidbody2D>().velocity);
        Destroy(this.gameObject);
    }
}
