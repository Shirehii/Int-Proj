using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
	public PlayerController pc;
    public PlayerCombat comb;
    public Rigidbody2D colly;
    public int pow = 500;
    public bool enemyShielded; //for shield powerup

	public void Awake()
	{
        if (gameObject.tag == "Attp1")
        {
            pc = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>();
            comb = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerCombat>();
        }
        if (gameObject.tag == "Attp2")
        {
            pc = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
            comb = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerCombat>();
        }
	}

    public void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.layer == 8)
        {
            enemyShielded = trigger.gameObject.GetComponent<PlayerCombat>().shielded;
            if (!enemyShielded)
            {
                if (gameObject.tag == "Attp1") //damage
                {
                    comb.TakeDamageOnPlayer2(20f);
                }
                if (gameObject.tag == "Attp2")
                {
                    comb.TakeDamageOnPlayer1(20f);
                }

                colly = trigger.gameObject.GetComponent<Rigidbody2D>(); //knockback
                if (pc.lastDirectionPressed == 1)
                {
                    colly.AddForce(new Vector2(pow, 0));
                }
                if (pc.lastDirectionPressed == -1)
                {
                    colly.AddForce(new Vector2(-pow, 0));
                }
            }
        }
    }

    public void LateUpdate()
    {
        gameObject.SetActive(false);
    }

    //F
}