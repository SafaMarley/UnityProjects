using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9.0f;
    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    public GameObject boss;
    public int enemiesAlive;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    void SpawnPowerup()
    {
        int randomIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomIndex], GenerateSpawnPosition(), powerupPrefabs[randomIndex].transform.rotation);
    }
    void SpawnEnemyWave(int enemyToSpawn)
    {
        if (waveNumber % 4 == 0)
        {
            Instantiate(boss, GenerateSpawnPosition(), boss.gameObject.transform.rotation);
        }
        else
        {
            for (int i = 0; i < enemyToSpawn; i++)
            {
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[randomIndex], GenerateSpawnPosition(), enemyPrefabs[randomIndex].transform.rotation);
            }   
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemiesAlive = FindObjectsOfType<EnemyMovement>().Length;
        if (enemiesAlive == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomPosX = Random.Range(-spawnRange, spawnRange);
        float randomPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(randomPosX, 0, randomPosZ);

        return randomPos;
    }
}
