using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float repeatRate = 3.0f;
    private float spawnMin = 0.0f;
    private float spawnMax = 2.0f;
    private int ballPrefabsSize = 3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, repeatRate);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        Invoke("SpawnBall", Random.Range(spawnMin, spawnMax));
        
    }

    void SpawnBall()
    {
        //Debug.Log(Time.time);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[Random.Range(0 ,ballPrefabsSize)], spawnPos, ballPrefabs[0].transform.rotation);
    }

}
