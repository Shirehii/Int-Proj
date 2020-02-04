using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float plrSpd;
    public float jmpSpd;
    public Movement mvmnt;

    //movement variables
    public int moveP1;
    public int moveP2;
    private bool jump = false;

    void Start()
    {

    }

    //Player Input
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveP1 = -1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveP1 = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveP2 = -1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveP2 = -1;
        }

    }

    //Movement Physics
    void FixedUpdate()
    {
        if (moveP1 != 0 || moveP2 != 0)
        {
            mvmnt.Move();
        }
    }

    //F
}
