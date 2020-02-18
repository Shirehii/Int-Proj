using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public PlayerController pc;
    private Animator animator;

    private void Start()
    {
        //Get Components
        pc = gameObject.GetComponent<PlayerController>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        animator.Play("Idle");
    }
}