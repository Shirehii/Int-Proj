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
            rb.velocity = pc.plrSpd * new Vector2(pc.directionP1 * pc.plrSpd, rb.velocity.y);
        }

        if (pc.directionP2 != 0)
        {
            rig.velocity = pc.plrSpd * new Vector2(pc.directionP2 * pc.plrSpd, rig.velocity.y);
        }
    }

    public void Jump()
    {
        if (pc.jumpP1 == true)
        {
            GroundCheck();
            if (isGroundedP1 == true)
            {
                rb.AddForce(new Vector2(0, pc.jmpSpd));
            }
        }

        if (pc.jumpP2 == true)
        {
            rig.AddForce(new Vector2(0, pc.jmpSpd));
        }
    }

    void GroundCheck()
    {
        //ADD GROUND CHECK CONDITIONS HERE
    }

    //F
}