using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Component variables
    public Rigidbody2D rb;
    public PlayerController pc;

    //Physics variables
    private float baseSpeed;
    public bool isGrounded; //for jumping
    public bool isFlying; //for other mechanics

    private void Awake()
    {
        //Get Components
        rb = gameObject.GetComponent<Rigidbody2D>();
        pc = gameObject.GetComponent<PlayerController>();

        //Initialize
        baseSpeed = pc.plrSpd;
    }
    
    public void Stand() //Standing
    {
        pc.plrSpd = baseSpeed;
        pc.stand = false;
    }

    public void Crouch() //Crouching
    {
        if (isGrounded)
        {
            pc.plrSpd = pc.plrSpd - baseSpeed * 80/100;
            pc.crouch = false;
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

    private void OnCollisionExit2D(Collision2D col) //GroundCheck the Sequel(tm)
    {
        if (col.gameObject.tag == "Platform")
        {
            isFlying = true;
        }
    }

    //F
}