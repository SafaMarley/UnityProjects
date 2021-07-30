using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce;
    public float gravityModifier = 2f;
    public float playerLocation = 2.5f;
    public float playerSpeed = 10.0f;
    public bool isOnGround = true;
    public bool gameOver;
    public bool doubleJump = true;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < playerLocation)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
            {
                if (isOnGround)
                {
                    isOnGround = false;
                    jump();
                }
                else if (doubleJump)
                {
                    doubleJump = false;
                    jump();
                }
            }
        }
    }

    void jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        dirtParticle.Stop();
        playerAnim.SetTrigger("Jump_trig");
        playerAudio.PlayOneShot(jumpSound, 0.8f);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            dirtParticle.Play();
            isOnGround = true;
            doubleJump = true;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetInteger("DeathType_int", 1);
            playerAnim.SetBool("Death_b", true);
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 0.8f);
            Debug.Log("Your score = " + MoveLeft.score / 100);
        }
    }
}
