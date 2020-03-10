using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float Player1HPMax = 100;
    public float Player1HPCurrent;

    public float Player2HPMax = 100;
    public float Player2HPCurrent;

    public GameObject attp1;
    public GameObject attp2;

    public PlayerController pc;
    public HitCheck hc;


    public void Awake()
    {
        pc = gameObject.GetComponent<PlayerController>();

        attp1 = GameObject.FindGameObjectWithTag("Attp1");
        attp2 = GameObject.FindGameObjectWithTag("Attp2");
    }
    private void Start()
    {
        Player1HPCurrent = Player1HPMax;
        Player2HPCurrent = Player2HPMax;

        attp1.SetActive(false);
        attp2.SetActive(false);
    }


    public void Attackplr()
    {
        if (gameObject.tag == "Player1")
        {
            attp1.SetActive(true);
            TakeDamageOnPlayer2(20f);
        }
        if (gameObject.tag == "Player2")
        {
            attp2.SetActive(true);
            TakeDamageOnPlayer1(20f);
        }
        pc.attackPlr = false;
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

    //F
}
