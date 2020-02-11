using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerController pc;

    private bool isGrounded;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        pc = gameObject.GetComponent<PlayerController>();
    }

    public void Crouch()
    {
        if (isGrounded)
        {
            pc.plrSpd
        }
    }
    public void Move() //Horizontal movement
    {
        if (pc.direction != 0)
        {
            rb.velocity = new Vector2(pc.direction * pc.plrSpd, rb.velocity.y);
        }
    }

    public void Jump() //Jumping
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

    private void OnCollisionEnter2D(Collision2D col) //GroundCheck
    {
        if (col.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    //F
}