using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private float acceleration = 10f;

    [SerializeField]
    private float speed = 15f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void MoveInDirection(Vector2 direction)
    {
        direction = Vector3.Normalize(direction);

        Vector2 newVelocity = rb.velocity + (direction * acceleration * Time.deltaTime);

        newVelocity.x = Mathf.Clamp(newVelocity.x, -speed, speed);
        newVelocity.y = Mathf.Clamp(newVelocity.y, -speed, speed);

        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));

        rb.velocity = newVelocity;
    }
}
