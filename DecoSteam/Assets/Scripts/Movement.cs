using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerController pc;

    private bool isGrounded;

    public void Move()
    {
        if (pc.direction != 0)
        {
            rb.velocity = new Vector2(pc.direction * pc.plrSpd, rb.velocity.y);
        }
    }

    public void Jump()
    {
        if (pc.jump == true)
        {
            pc.jump = false;
            if (isGrounded == true)
            {
                rb.AddForce(new Vector2(0, pc.jmpSpd));
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    //F
}