using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDamage : MonoBehaviour
{
    public static int lives = 3;

    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives = " + lives);
        Debug.Log("Score = " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        lives--;
        if (lives == 0)
        {
            Debug.Log("Game Over!!!");
        }
        else
        {
            Debug.Log("Hit! Lives = " + lives);
        }
    }
}
