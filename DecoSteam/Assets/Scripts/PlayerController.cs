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

    //Player Input
    void Update()
    {
        //--PLAYER 1 INPUTS--
        if (Input.GetKeyDown(KeyCode.A)) //Left
        {
            directionP1 = -1;
        }

        if (Input.GetKeyDown(KeyCode.D)) //Right
        {
            directionP1 = 1;
        }
        
        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false) //Stop
        {
            directionP1 = 0;
        }

        if (Input.GetKey(KeyCode.W)) //Jump
        {
            jumpP1 = true;
        }

        //--PLAYER 2 INPUTS--
        if (Input.GetKeyDown(KeyCode.LeftArrow)) //Left
        {
            directionP2 = -1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) //Right
        {
            directionP2 = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false) //Stop
        {
            directionP2 = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow)) //Jump
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
