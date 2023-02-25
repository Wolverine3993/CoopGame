using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer lineRenderer;
    Transform firePoint;
    Transform particle;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        firePoint = transform.GetChild(0).transform;
        particle = transform.GetChild(1).transform;
    }
    void Update()
    {
        DrawThing(GetTarget());
    }
    void DrawThing(Vector2 target)
    {
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target);
        particle.position = target;
    }
    Vector2 GetTarget()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(firePoint.position, Vector2.right);
        return raycastHit.point;
    }
}
