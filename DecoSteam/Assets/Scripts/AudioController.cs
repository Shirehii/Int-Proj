using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //SFX clips
    public AudioClip jumpAudio;
    public AudioClip doubleJumpAudio;
    public AudioClip damageAudio;
    public AudioClip shieldDamageAudio;
    public AudioClip deathAudio;
    public AudioClip pickUpShieldAudio;
    public AudioClip pickUpSpeedAudio;

    //Scripts for checking what the players are doing
    public PlayerController pc1;
    public PlayerController pc2;
    public Movement mvmnt1;
    public Movement mvmnt2;
    public PlayerCombat comb1;
    public PlayerCombat comb2;
    public HitCheck hc1;
    public HitCheck hc2;
    public SceneCycling sceneCycle;

    //Audio Source
    public AudioSource source;

    private void Start()
    {
        //Get Scripts
        sceneCycle = GetComponent<SceneCycling>();
        if (sceneCycle.currentScene != "Main Menu")
        {
            pc1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerController>();
            pc2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController>();
            mvmnt1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Movement>();
            mvmnt2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Movement>();
            comb1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerCombat>();
            comb2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerCombat>();
            hc1 = GameObject.FindGameObjectWithTag("Attp1").GetComponent<HitCheck>();
            hc2 = GameObject.FindGameObjectWithTag("Attp2").GetComponent<HitCheck>();
        }

        //Get AudioSource
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (sceneCycle.currentScene != "Main Menu")
        {
            //Jumping Audio
            if ((pc1.jump && mvmnt1.jumpCount == 0) || (pc2.jump && mvmnt2.jumpCount == 0)) //Single jump
            {
                Debug.Log("1jump");
                source.PlayOneShot(jumpAudio);
            }
            if ((pc1.jump && mvmnt1.jumpCount == 1) || (pc2.jump && mvmnt2.jumpCount == 1)) //Double Jump
            {
                Debug.Log("2jump");
                source.PlayOneShot(doubleJumpAudio);
            }

            //Attacking Audio
            if ((pc1.attackPlr && !hc1.enemyShielded) || (pc2.attackPlr && !hc2.enemyShielded)) //Basic Attack
            {
                source.PlayOneShot(damageAudio);
            }
            if ((pc1.attackPlr && hc1.enemyShielded) || (pc2.attackPlr && hc2.enemyShielded)) //Hitting enemy shield
            {
                source.PlayOneShot(shieldDamageAudio);
            }
            if (comb1.dead || comb2.dead) //Dying
            {
                source.PlayOneShot(deathAudio);
            }
        }
    }

    private void FixedUpdate()
    {
        if (sceneCycle.currentScene != "Main Menu")
        {
            //Jumping Audio
            if ((pc1.jump && mvmnt1.jumpCount == 0) || (pc2.jump && mvmnt2.jumpCount == 0)) //Single jump
            {
                Debug.Log("1jump");
                source.PlayOneShot(jumpAudio);
            }
            if ((pc1.jump && mvmnt1.jumpCount == 1) || (pc2.jump && mvmnt2.jumpCount == 1)) //Double Jump
            {
                Debug.Log("2jump");
                source.PlayOneShot(doubleJumpAudio);
            }

            //Attacking Audio
            if ((pc1.attackPlr && !hc1.enemyShielded) || (pc2.attackPlr && !hc2.enemyShielded)) //Basic Attack
            {
                source.PlayOneShot(damageAudio);
            }
            if ((pc1.attackPlr && hc1.enemyShielded) || (pc2.attackPlr && hc2.enemyShielded)) //Hitting enemy shield
            {
                source.PlayOneShot(shieldDamageAudio);
            }
            if (comb1.dead || comb2.dead) //Dying
            {
                source.PlayOneShot(deathAudio);
            }

            //Powerup pickup Audio
            if (comb1.timeLeftShield > 9.95f || comb2.timeLeftShield > 9.95f)
            {
                source.PlayOneShot(pickUpShieldAudio);
            }
            if (mvmnt1.timeLeftSpeed > 9.95f || mvmnt2.timeLeftSpeed > 9.95f)
            {
                source.PlayOneShot(pickUpSpeedAudio);
            }
        }
    }

    //F
}
