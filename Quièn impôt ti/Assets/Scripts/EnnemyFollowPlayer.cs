using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFollowPlayer : MonoBehaviour
{
    public float moveForce = 10f;
    public float maxSpeed = 5f;
    private Rigidbody2D rb;
    private Transform target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;

        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(direction * moveForce);
        }
    }
}
