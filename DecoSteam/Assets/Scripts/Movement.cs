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
        rb.velocity = pc.plrSpd * new Vector2(pc.moveP1 * pc.plrSpd, rb.velocity.y);
        rig.velocity = pc.plrSpd * new Vector2(pc.moveP2 * pc.plrSpd, rb.velocity.y);
    }

    void Jump()
    {

    }

    //F
}