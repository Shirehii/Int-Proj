using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float plrSpd;
    public float jmpSpd;
    public Movement mvmnt;

    //movement variables
    public int direction;
    public bool jump = false;

    //Player Input
    void Update()
    {
        //--PLAYER 1 INPUTS--
        if (gameObject.tag == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.A)) //Left
            {
                direction = -1;
            }

            if (Input.GetKeyDown(KeyCode.D)) //Right
            {
                direction = 1;
            }

            if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false) //Stop
            {
                direction = 0;
            }

            if (Input.GetKey(KeyCode.W)) //Jump
            {
                jump = true;
            }
        }

        //--PLAYER 2 INPUTS--
        if (gameObject.tag == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) //Left
            {
                direction = -1;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow)) //Right
            {
                direction = 1;
            }

            if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false) //Stop
            {
                direction = 0;
            }

            if (Input.GetKey(KeyCode.UpArrow)) //Jump
            {
                jump = true;
            }
        }
    }

    //Movement Physics
    void FixedUpdate()
    {
        if (direction != 0)
        {
            mvmnt.Move();
        }

        if (jump)
        {
            mvmnt.Jump();
        }
    }

    //F
}
