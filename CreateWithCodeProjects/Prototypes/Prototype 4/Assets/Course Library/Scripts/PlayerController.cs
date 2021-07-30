using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    private float powerupStrength = 15.0f;
    public float speed;
    public float smashForce;
    public float smashDownForce;
    public float explosionRadius;
    public bool hasPowerup;
    public bool hasPowerup2;
    public bool hasPowerup3;
    private float powerup2StartDelay = 0f;
    private float powerup2RepeatDelay = 1f;
    public GameObject bullets;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerupIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
        else if (other.CompareTag("Powerup2"))
        {
            hasPowerup2 = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine2());
            InvokeRepeating("FireBullets", powerup2StartDelay,powerup2RepeatDelay);
        }
        else if (other.CompareTag("Powerup3"))
        {
            hasPowerup3 = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine3());
            SmashIt();
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    
    IEnumerator PowerupCountdownRoutine2()
    {
        yield return new WaitForSeconds(7);
        hasPowerup2 = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    
    IEnumerator PowerupCountdownRoutine3()
    {
        yield return new WaitForSeconds(2);
        hasPowerup3 = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("0*0");
        }
    }

    public void FireBullets()
    {
        if (hasPowerup2)
        {
            //Debug.Log("Bang");
            Instantiate(bullets, gameObject.transform.position, bullets.transform.rotation);
        }
    }

    public void SmashIt()
    {
        Debug.Log("taken");
        playerRb.AddForce(Vector3.up * smashForce);
        StartCoroutine(SmashRoutine());
        
    }
    
    IEnumerator SmashRoutine()
    {
        var enemies = FindObjectsOfType<EnemyMovement>();
        
        yield return new WaitForSeconds(1);
        playerRb.AddForce(Vector3.down * smashDownForce);
        yield return new WaitForSeconds(0.25f);

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(smashDownForce, transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
            }
        }
    }
}
