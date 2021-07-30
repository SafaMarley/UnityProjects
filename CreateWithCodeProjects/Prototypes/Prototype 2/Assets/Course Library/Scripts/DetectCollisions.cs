using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public Slider hungerSlider;
    public int hungerAmount;
    public int currentAmount = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        Destroy(other.gameObject);
        DetectDamage.score += 10;
        Debug.Log("Score = " + DetectDamage.score);
        hungerSlider.maxValue = hungerAmount;
        beingFed();
    }
    public void beingFed()
    {
        currentAmount++;
        if (currentAmount == hungerSlider.maxValue)
        {
            Destroy(gameObject);
        }
        else
        {
            hungerSlider.value = currentAmount;
        }
        
    }
}
