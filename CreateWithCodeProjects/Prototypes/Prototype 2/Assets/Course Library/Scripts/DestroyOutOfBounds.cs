using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 25.0f;
    public float lowerBound = -10.0f;
    public float rangeX = 25.0f;

    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            DetectDamage.lives--;
            if (DetectDamage.lives == 0)
            {
                Debug.Log("Game Over!");
            }
            else
            {
                Debug.Log("Missed! Lives = " + DetectDamage.lives);
            }
        }
        else if (transform.position.x > rangeX)
        {
            Destroy(gameObject);
            DetectDamage.lives--;
            if (DetectDamage.lives == 0)
            {
                Debug.Log("Game Over!");
            }
            else
            {
                Debug.Log("Missed! Lives = " + DetectDamage.lives);
            }
        }
        else if (transform.position.x < -rangeX)
        {
            Destroy(gameObject);
            DetectDamage.lives--;
            if (DetectDamage.lives == 0)
            {
                Debug.Log("Game Over!");
            }
            else
            {
                Debug.Log("Missed! Lives = " + DetectDamage.lives);
            }
        }
    }
}
