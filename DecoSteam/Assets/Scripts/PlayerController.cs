using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float plrSpd;
    public float jmpSpd;
    public Movement mvmnt;
    public PlayerCombat comb;

    //movement variables
    public int direction;
    public int lastDirectionPressed = 1;
    public bool flip = false;
    public bool jump = false;
    public bool crouch = false;
    public bool stand = false;
    public bool slam = false;
    public bool attackPlr = false;

    private void Awake()
    {
        //Get Components
        mvmnt = GetComponent<Movement>();
        comb = GetComponent<PlayerCombat>();
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

            if (Input.GetKeyDown(KeyCode.S) && mvmnt.jumpCount == 0) //Crouch
            {
                stand = false;
                crouch = true;
            }
            else if (Input.GetKeyUp(KeyCode.S) && mvmnt.jumpCount == 0) //Standing
            {
                stand = true;
                crouch = false;
            }

            if (Input.GetKey(KeyCode.S) && mvmnt.jumpCount > 0) //Ground Slam
            {
                slam = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackPlr = true;
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

            if (Input.GetKeyDown(KeyCode.DownArrow) && mvmnt.jumpCount == 0) //Crouch
            {
                stand = false;
                crouch = true;
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) && mvmnt.jumpCount == 0) //Standing
            {
                stand = true;
                crouch = false;
            }

            if (Input.GetKey(KeyCode.DownArrow) && mvmnt.jumpCount > 0) //Ground Slam
            {
                slam = true;
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                attackPlr = true;
            }
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && direction != lastDirectionPressed) //For flipping the player sprite
        {
            flip = true;
            lastDirectionPressed = direction;
        }
    }

    //Movement Physics
    void FixedUpdate()
    {
        if (direction != 0)
        {
            mvmnt.Move();
            if (flip)
            {
                mvmnt.Flip();
            }
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

        if (attackPlr)
        {
            comb.Attackplr();
        }
    }

    //F
}