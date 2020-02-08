using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float plrSpd;
    public float jmpSpd;
    public Movement mvmnt;

    //movement variables
    public int directionP1;
    public int directionP2;
    public bool jumpP1 = false;
    public bool jumpP2 = false;

    void Start()
    {

    }

    //Player Input
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            directionP1 = -1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            directionP1 = 1;
        }
        
        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            directionP1 = 0;
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            directionP2 = -1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            directionP2 = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false)
        {
            directionP2 = 0;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            jumpP1 = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            jumpP2 = true;
        }
    }

    //Movement Physics
    void FixedUpdate()
    {
        if (directionP1 != 0 || directionP2 != 0)
        {
            mvmnt.Move();
        }

        if (jumpP1 == true || jumpP2 == true)
        {
            mvmnt.Jump();
        }
    }

    //F
}
