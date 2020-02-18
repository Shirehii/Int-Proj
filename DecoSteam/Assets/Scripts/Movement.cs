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
    public int isGrounded = 0; //for jumping

    //Powerup variables
    public bool canDoubleJump;

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
        if (isGrounded == 0)
        {
            pc.plrSpd = pc.plrSpd - baseSpeed * 80/100;
            pc.crouch = false;
        }
    }

    public void GroundSlam() //Ground Slam
    {
        if (isGrounded > 0)
        {
            rb.velocity = new Vector2(0, pc.plrSpd * -3);;
            pc.slam = false;
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
            if (isGrounded == 0)
            {
                rb.AddForce(new Vector2(0, pc.jmpSpd));
                isGrounded = 1;
                canDoubleJump = true;
            }
            else if (isGrounded == 1)
            {
                DoubleJump();
            }
            pc.jump = false;
        }
    }

    public void DoubleJump() //Double Jumping
    {   
        if (isGrounded == 1 && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, pc.jmpSpd));
            isGrounded = 2;
            canDoubleJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) //GroundCheck
    {
        if (col.gameObject.tag == "Platform")
        {
            isGrounded = 0;
            canDoubleJump = false;
        }
    }

    //F
}