using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer lineRenderer;
    Transform firePoint;
    Transform particle;
    Collider2D collider;
    [SerializeField] bool on = true;
    [SerializeField] bool startOn = true;
    void Start()
    {
        collider = GetComponent<Collider2D>(); 
        lineRenderer = GetComponent<LineRenderer>();
        firePoint = transform.GetChild(0).transform;
        particle = transform.GetChild(1).transform;
    }
    void Update()
    {
        if (on)
            DrawThing(GetTarget());
        else
        {
            lineRenderer.enabled = false;
            particle.gameObject.SetActive(false);
        }
    }
    void DrawThing(Vector2 target)
    {
        lineRenderer.enabled = true;
        particle.gameObject.SetActive(true);
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target);
        particle.position = target;
    }
    Vector2 GetTarget()
    {
        RaycastHit2D xPosTar = Physics2D.Raycast(firePoint.position, Vector2.right);
        RaycastHit2D raycastHit = Physics2D.BoxCast(new Vector2(firePoint.position.x + 0.1f, firePoint.position.y), new Vector2(0.01f, collider.bounds.size.y), 0, Vector2.right, xPosTar.distance);
        if (raycastHit.collider.gameObject.CompareTag("Player"))
            raycastHit.collider.gameObject.GetComponent<PlayerDeath>().Die();
        return new Vector2(raycastHit.point.x, transform.position.y);
    }
    public void ChangeState(bool state)
    {
        if (startOn)
        {
            on = state;
            return;
        }
        on = !state;
    }
}
