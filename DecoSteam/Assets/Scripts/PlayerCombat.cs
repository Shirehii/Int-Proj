using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackpoint;
    public float attrange = 0.5f;


    public float Player1HPMax = 100;
    public float Player1HPCurrent;
    public LayerMask Plr1;

    public float Player2HPMax = 100;
    public float Player2HPCurrent;
    public LayerMask Plr2;


    private void Start()
    {
        Player1HPCurrent = Player1HPMax;
        Player2HPCurrent = Player2HPMax;

    }

    public void AttackingForPlayer1()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attrange, Plr2);


        foreach (Collider2D enemy in hitEnemies);
        {
            TakeDamageOnPlayer2(20);
        }
    }

    public void AttackingForPlayer2()
    {
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attrange, Plr1);


        foreach (Collider2D enemy in hitenemies);
        {
            TakeDamageOnPlayer1(20);
        }
    }

    public void TakeDamageOnPlayer1(float Player2Damage)
    {
        Player1HPCurrent -= Player2Damage;

        if (Player1HPCurrent <= 0)
        {
            Die();
        }
    }

    public void TakeDamageOnPlayer2(float Player1Damage)
    {
        Player2HPCurrent -= Player1Damage;

        if (Player2HPCurrent <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Debug.Log("I have died.");
    }
}
