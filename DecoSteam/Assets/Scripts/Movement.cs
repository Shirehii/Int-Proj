using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rig;
    public PlayerController pc;

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

    }

    //F
}