using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
	public PlayerController pc;
    public Rigidbody2D colly;
    public int pow = 5000;

	public void Awake()
	{
        if (gameObject.tag == "Attp1")
        {
            pc = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>();
        }
        if (gameObject.tag == "Attp2")
        {
            pc = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
        }
	}

    public void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.layer == 8)
        {
            colly = col.gameObject.GetComponent<Rigidbody2D>();

            if (pc.lastDirectionPressed == 1)
            {
                colly.AddForce(new Vector2(pow, 0));
            }
            if (pc.lastDirectionPressed == -1)
            {
                colly.AddForce(new Vector2(-pow, 0));
            }
        }
        gameObject.SetActive(false);
    }
}