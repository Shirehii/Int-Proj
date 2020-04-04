using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Component variables
    public Rigidbody2D rb;
    public PlayerController pc;

    public PlayerCombat comb;

    //Physics variables
    private float baseSpeed;
    public int jumpCount = 0; //for jumping
    public bool canDoubleJump;

    private void Awake()
    {
        //Get Components
        rb = gameObject.GetComponent<Rigidbody2D>();
        pc = gameObject.GetComponent<PlayerController>();

        comb = GetComponent<PlayerCombat>();

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
        if (jumpCount == 0)
        {
            pc.plrSpd -= baseSpeed * 80/100;
            pc.crouch = false;
        }
    }

    public void GroundSlam() //Ground Slam
    {
        if (jumpCount > 0)
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

    public void Flip() //Flipping the sprite
    {
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
        pc.flip = false;
    }

    public void Jump() //Jumping
    {
        if (pc.jump == true)
        {
            if (jumpCount == 0)
            {
                rb.AddForce(new Vector2(0, pc.jmpSpd));
                jumpCount = 1;
                canDoubleJump = true;
            }
            else if (jumpCount == 1)
            {
                DoubleJump();
            }
            pc.jump = false;
        }
    }

    public void DoubleJump() //Double Jumping
    {   
        if (jumpCount == 1 && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, pc.jmpSpd));
            jumpCount = 2;
            canDoubleJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) //GroundCheck
    {
        if (col.gameObject.tag == "Platform")
        {
            jumpCount = 0;
            canDoubleJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "SpeedBoost") //Speed Boost
        {
            Destroy(trigger.gameObject);
            pc.plrSpd *= 2;
        }

        if (trigger.gameObject.tag == "Death") //Fall zone
        {
            comb.dead = true;
            Destroy(gameObject);
        }
    }

    //F
}