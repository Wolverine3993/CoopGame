using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OneWayWall : MonoBehaviour
{
    Collider2D doorCollider;
    void Start()
    {
        doorCollider = transform.GetChild(0).gameObject.GetComponent<Collider2D>();
    }
    public void IgnoreCollisionFunc(bool _collision, Collider2D player)
    {
        Physics2D.IgnoreCollision(doorCollider, player, _collision);
    }
}
