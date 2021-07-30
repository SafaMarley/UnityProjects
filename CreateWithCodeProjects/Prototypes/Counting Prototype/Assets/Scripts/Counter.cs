using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Counter : MonoBehaviour
{
    public GameObject fish;
    public GameObject gameOverScreen;
    public Text CounterText;
    public Text RemainingTimeText;
    public float verticalInput;
    public float horizontalInput;
    public float speedMultiplier;

    private int Count;
    private int remainingTime;
    private int secondToAdd = 5;
    private float startDelay = 0f;
    private float repeatDelay = 0.5f;
    private float spawnRange = 45.0f;
    private bool isGameActive = true;

    //private Rigidbody playerRb;

    private void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
        Count = 0;
        remainingTime = 10;
        StartCoroutine(countDown());
        InvokeRepeating("FishSpawner", startDelay, repeatDelay);
    }

    private void Update()
    {
        if (isGameActive)
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.forward * verticalInput * speedMultiplier * Time.deltaTime);
            transform.Translate(Vector3.right * horizontalInput * speedMultiplier * Time.deltaTime);
            //playerRb.AddForce(Vector3.forward * verticalInput * speedMultiplier);
            //playerRb.AddForce(Vector3.right * horizontalInput * speedMultiplier);

            if (transform.position.x > 50)
            {
                transform.position = new Vector3(50, transform.position.y, transform.position.z);
            }

            if (transform.position.z > 50)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 50);
            }

            if (transform.position.x < -50)
            {
                transform.position = new Vector3(-50, transform.position.y, transform.position.z);
            }

            if (transform.position.z < -50)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -50);
            }
        }
    }

    void FishSpawner()
    {
        if (isGameActive)
        {
            Instantiate(fish, randomPosition(), fish.gameObject.transform.rotation);
        }
    }
    

    Vector3 randomPosition()
    {
        Vector3 randomPositionVector = new Vector3(Random.Range(spawnRange, -spawnRange), 50, Random.Range(spawnRange, -spawnRange));
        return randomPositionVector;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Destroy(other.gameObject);
            Count++;
            CounterText.text = "Score: " + Count;
            remainingTime += secondToAdd;
        }
    }

    IEnumerator countDown()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            remainingTime--;
            //Debug.Log("hi");
            RemainingTimeText.text = "RemainingTime : " + remainingTime;
            if (remainingTime == 0)
            {
                gameOverScreen.gameObject.SetActive(true);
                isGameActive = false;
                //Debug.Log("selam");
            }
        }
    }
}
