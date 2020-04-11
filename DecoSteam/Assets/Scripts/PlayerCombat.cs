using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float Player1HPMax = 100;
    public float Player1HPCurrent;

    public float Player2HPMax = 100;
    public float Player2HPCurrent;

    public BoxCollider2D attp;

    public PlayerController pc;
    public HitCheck hc;

    public float timeLeftShield;
    public bool shielded = false;
    public bool dead = false;


    public void Awake()
    {
        pc = gameObject.GetComponent<PlayerController>();
        
        if (gameObject.tag == "Player1")
        {
            attp = GameObject.FindGameObjectWithTag("Attp1").GetComponent<BoxCollider2D>();
            hc = attp.GetComponent<HitCheck>();
        }
        if (gameObject.tag == "Player2")
        {
            attp = GameObject.FindGameObjectWithTag("Attp2").GetComponent<BoxCollider2D>();
            hc = attp.GetComponent<HitCheck>();
        }
    }

    private void Start()
    {
        Player1HPCurrent = Player1HPMax;
        Player2HPCurrent = Player2HPMax;

        attp.enabled = false;
    }

    void Update()
    {
        if (timeLeftShield > 0)
        {
            timeLeftShield -= Time.deltaTime;
        }
        else if (timeLeftShield <= 0)
        {
            shielded = false;
        }
    }

    public void Attackplr()
    {
        attp.enabled = true;
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
        dead = true;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Shield") //Shield
        {
            Destroy(trigger.gameObject);
            shielded = true;
            
            timeLeftShield = 10.0f;
        }
    }

    //F
    }