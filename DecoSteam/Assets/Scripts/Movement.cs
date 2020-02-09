using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rig;
    public PlayerController pc;

    private bool isGroundedP1;
    private bool isGroundedP2;

    public void Move()
    {
        if (pc.directionP1 != 0)
        {
            rb.velocity = new Vector2(pc.directionP1 * pc.plrSpd, rb.velocity.y);
        }

        if (pc.directionP2 != 0)
        {
            rig.velocity = new Vector2(pc.directionP2 * pc.plrSpd, rig.velocity.y);
        }
    }

    public void Jump()
    {
        if (pc.jumpP1 == true)
        {
            pc.jumpP1 = false;
            if (isGroundedP1 == true)
            {
                rb.AddForce(new Vector2(0, pc.jmpSpd));
                isGroundedP1 = false;
            }
        }

        if (pc.jumpP2 == true)
        {
            pc.jumpP2 = false;
            if (isGroundedP2 == true)
            {
                rig.AddForce(new Vector2(0, pc.jmpSpd));
                isGroundedP2 = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform" && gameObject.tag == "Player1")
        {
            isGroundedP1 = true;
        }

        if (col.gameObject.tag == "Platform" && gameObject.tag == "Player2")
        {
            isGroundedP2 = true;
        }
    }

    //F
}