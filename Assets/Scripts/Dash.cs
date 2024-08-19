using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Dash : MonoBehaviour
{
    private bool canDash = true;
    public bool isDashing;
    private float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 2f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Dashing()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        if(!spriteRenderer.flipX)
        {
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
        }

        tr.emitting = true;
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Dash_Multi");

        //rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
