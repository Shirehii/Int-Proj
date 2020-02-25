using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHits : MonoBehaviour
{
    public PlayerCombat comb;
    public PlayerController pc;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            comb.TakeDamageOnPlayer1(20);
        }

        if (other.tag == "Player2")
        {
            comb.TakeDamageOnPlayer2(20);
        }
    }
}
