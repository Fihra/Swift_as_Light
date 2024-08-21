using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Movement movement;
    Jump jumper;
    Dash dasher;
    Animator animator;

    bool isFacingRight = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<Movement>();
        jumper = GetComponent<Jump>();
        dasher = GetComponent<Dash>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(dasher.isDashing)
        {
            return;
        }

        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        FlipSprite(horizontalMovement);

        Vector2 newHorizontalPosition = new Vector2(horizontalMovement, 0);

        movement.MoveInDirection(newHorizontalPosition);

        if(Input.GetKey(KeyCode.Space))
        {
            jumper.Jumping();
        }

        jumper.WallSlide();
       
        if(Input.GetKey(KeyCode.Z))
        {
            StartCoroutine(dasher.Dashing());
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            movement.FallingSpeed();
        } 
        else
        {
            movement.ResetGravity();
        }

        //if(Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    movement.ResetGravity();
        //}    
    }

    void FlipSprite(float horizontal)
    {
        if(horizontal > 0f)
        {
            spriteRenderer.flipX = false;
        }
        
        if(horizontal < 0f)
        {
            spriteRenderer.flipX = true;
        }


    }
}
