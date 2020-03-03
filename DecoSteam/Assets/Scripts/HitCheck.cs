using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public PlayerCombat comb;
    public Movement mvmnt;
    public Rigidbody2D colly;
    public float pow = 2500f;


    public void OnTriggerEnter2D(Collider2D col) //GroundCheck
    {
        Debug.Log("ATTACK");

        

        colly = col.gameObject.GetComponent<Rigidbody2D>();
        colly.AddForce(new Vector2(pow, 0));

        gameObject.SetActive(false);
    }
}
