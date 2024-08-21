using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 10f;

    private Rigidbody2D rb;
    private GroundDetector groundDetector;

    Animator animator;

    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private LayerMask wallLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector>();
        animator = GetComponent<Animator>();
    }

    public void Jumping()
    {
        if(groundDetector == null || groundDetector.onGround == true)
        {
            rb.velocity += new Vector2(0f, jumpForce);
            animator.SetBool("isJumping", !groundDetector.onGround);
            animator.SetFloat("yVelocity", 1);

            if (rb.velocity.y > jumpForce)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    public void WallSlide()
    {
        if(IsWalled() && !groundDetector.onGround && rb.position.y != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }
}
