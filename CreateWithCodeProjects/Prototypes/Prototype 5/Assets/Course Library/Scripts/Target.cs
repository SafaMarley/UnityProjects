using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float xPositionRange = 4f;
    private float yPosition = -4f;
    private float minSpeed = 12f;
    private float maxSpeed = 16f;

    public int scorePoints;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        transform.position = new Vector3(Random.Range(-xPositionRange, xPositionRange), yPosition);
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnMouseEnter()
    {
        Debug.Log("selam");
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Destroy(gameObject);
            gameManager.UpdateScore(scorePoints);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Good"))
        {
            gameManager.GameOver();
        }
    }

    float randomTorque()
    {
        return Random.Range(-10f, 10f);
    }
}
