using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silly : MonoBehaviour
{
    [SerializeField] Collider2D[] boxes;
    Collider2D collander;
    void Start()
    {
        collander = GetComponent<Collider2D>();
        foreach (Collider2D b in boxes)
            Physics2D.IgnoreCollision(collander, b);
    }
}
