using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer lineRenderer;
    Transform firePoint;
    Transform particle;
    Collider2D coll;
    [SerializeField] bool on = true;
    [SerializeField] bool startOn = true;
    enum _dir
    {
        Up,
        Down,
        Left,
        Right
    }
    [SerializeField] _dir Direction;
    delegate Vector2 Target();
    Target GetTarget;
    void Start()
    {
        switch (Direction.ToString())
        {
            case "Right":
                GetTarget = GetTargetRight;
                break;
            case "Down":
                GetTarget = GetTargetDown;
                break;
            case "Up":
                GetTarget = GetTargetUp;
                break;
            case "Left":
                GetTarget = GetTargetLeft;
                break;
        }
        coll = GetComponent<Collider2D>();
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
    Vector2 GetTargetRight()
    {
        RaycastHit2D xPosTar = Physics2D.Raycast(firePoint.position, Vector2.right);
        RaycastHit2D raycastHit = Physics2D.BoxCast(new Vector2(firePoint.position.x + 0.1f, firePoint.position.y), new Vector2(0.01f, coll.bounds.size.y * 0.75f), 0, Vector2.right, xPosTar.distance);
        if (raycastHit.collider.gameObject.CompareTag("Player"))
            raycastHit.collider.gameObject.GetComponent<PlayerDeath>().Die();
        return new Vector2(raycastHit.point.x, transform.position.y);
    }
    Vector2 GetTargetDown()
    {
        RaycastHit2D yPosTar = Physics2D.Raycast(firePoint.position, Vector2.down);
        RaycastHit2D raycastHit = Physics2D.BoxCast(new Vector2(firePoint.position.x, firePoint.position.y - 0.1f), new Vector2(coll.bounds.size.x * 0.75f, 0.01f), 0, Vector2.down, yPosTar.distance);
        if (raycastHit.collider.gameObject.CompareTag("Player"))
            raycastHit.collider.gameObject.GetComponent<PlayerDeath>().Die();
        return new Vector2(transform.position.x, raycastHit.point.y);
    }
    Vector2 GetTargetUp()
    {
        RaycastHit2D yPosTar = Physics2D.Raycast(firePoint.position, Vector2.up);
        RaycastHit2D raycastHit = Physics2D.BoxCast(new Vector2(firePoint.position.x, firePoint.position.y + 0.1f), new Vector2(coll.bounds.size.x * 0.75f, 0.01f), 0, Vector2.up, yPosTar.distance);
        if (raycastHit.collider.gameObject.CompareTag("Player"))
            raycastHit.collider.gameObject.GetComponent<PlayerDeath>().Die();
        return new Vector2(transform.position.x, raycastHit.point.y);
    }
    Vector2 GetTargetLeft()
    {
        RaycastHit2D xPosTar = Physics2D.Raycast(firePoint.position, Vector2.left);
        RaycastHit2D raycastHit = Physics2D.BoxCast(new Vector2(firePoint.position.x - 0.1f, firePoint.position.y), new Vector2(0.01f, coll.bounds.size.y * 0.75f), 0, Vector2.left, xPosTar.distance);
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
