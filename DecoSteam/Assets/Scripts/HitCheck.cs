using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public PlayerCombat comb;
    public Movement mvmnt;
	public PlayerController pc;
    public Rigidbody2D colly;
    public float pow = 2500f;
	public gameObject player;

	public void Awake()
	{
		pc = otherGameObject.GetComponent<"PlayerController">();
	}

    public void OnTriggerEnter2D(Collider2D col) 
    {
		if(pc.direction == 1)
		{
			colly = col.gameObject.GetComponent<Rigidbody2D>();
			colly.AddForce(new Vector2(pow, 0));
			gameObject.SetActive(false);
		}	
        if(pc.direction == -1)
		{
			colly = col.gameObject.GetComponent<Rigidbody2D>();
			colly.AddForce(new Vector2(-pow, 0));
			gameObject.SetActive(false);
		}
    }
}
