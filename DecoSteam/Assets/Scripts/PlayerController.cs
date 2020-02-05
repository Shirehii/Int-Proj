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
    private bool jump = false;

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

    }

    //Movement Physics
    void FixedUpdate()
    {
        if (directionP1 != 0 || directionP2 != 0)
        {
            mvmnt.Move();
        }
    }

    //F
}
