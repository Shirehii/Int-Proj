using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col) //GroundCheck
    {
        if (col.gameObject.tag == "Player1")
        {
            
        }
    }
}
