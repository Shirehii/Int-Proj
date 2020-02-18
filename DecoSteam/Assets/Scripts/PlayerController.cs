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
    public bool crouch = false;
    public bool stand = false;
    public bool slam = false;

    private void Awake()
    {
        //Get Components
        mvmnt = gameObject.GetComponent<Movement>();
    }

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

            if (Input.GetKeyDown(KeyCode.W)) //Jump
            {
                jump = true;
            }

            if (Input.GetKeyDown(KeyCode.S) && mvmnt.isGrounded == 0) //Crouch
            {
                stand = false;
                crouch = true;
            }
            else if (Input.GetKeyUp(KeyCode.S) && mvmnt.isGrounded == 0) //Standing
            {
                stand = true;
                crouch = false;
            }

            if (Input.GetKey(KeyCode.S) && mvmnt.isGrounded > 0) //Ground Slam
            {
                slam = true;
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

            if (Input.GetKeyDown(KeyCode.UpArrow)) //Jump
            {
                jump = true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && mvmnt.isGrounded == 0) //Crouch
            {
                stand = false;
                crouch = true;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) && mvmnt.isGrounded == 0) //Standing
            {
                stand = true;
                crouch = false;
            }

            if (Input.GetKey(KeyCode.DownArrow) && mvmnt.isGrounded > 0) //Ground Slam
            {
                slam = true;
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

        if (crouch)
        {
            mvmnt.Crouch();
        }

        if (stand)
        {
            mvmnt.Stand();
        }

        if (slam)
        {
            mvmnt.GroundSlam();
        }
    }

    //F
}