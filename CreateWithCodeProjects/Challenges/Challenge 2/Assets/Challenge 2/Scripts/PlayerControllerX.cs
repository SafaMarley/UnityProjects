using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float cooldown = 1.0f;
    private float cooldownTime;
    
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cooldownTime < Time.time)
            {
                cooldownTime = Time.time + cooldown;
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
            else
            {
                Debug.Log("Cooldown!");
            }
        }
    }
}
