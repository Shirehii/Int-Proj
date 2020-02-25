using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float Player1HPMax = 100;
    public float Player1HPCurrent;

    public float Player2HPMax = 100;
    public float Player2HPCurrent;

    public GameObject attp;

    public AttackHits atth;
    public PlayerController pc;

    private void Start()
    {
        Player1HPCurrent = Player1HPMax;
        Player2HPCurrent = Player2HPMax;
    }


    public void Awake()
    {
        if (gameObject.tag == "Player1")
        {
            attp = GameObject.FindGameObjectWithTag("AttackPoint1");
        }

        if (gameObject.tag == "Player2")
        {
            attp = GameObject.FindGameObjectWithTag("AttackPoint2");
        }

        pc = gameObject.GetComponent<PlayerController>();
    }

    public IEnumerator Attack()
    {
        gameObject.SetActive(attp);

        pc.attackPlr1 = false;
        pc.attackPlr2 = false;
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
