using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] unitArray;

    private float spawnRangeZ = 7f;
    private float spawnPointZ;
    private float spawnRangeX = 11f;
    private float spawnRate = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnEnemies");
    }

    IEnumerator spawnEnemies()
    {
        while (!EnemyUnits.isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int indexValue = GenerateRandomIndex();
            Instantiate(unitArray[indexValue], GenerateRandomPosition(),
                unitArray[indexValue].gameObject.transform.rotation);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        if (Random.Range(0, 2) == 0)
        {
            spawnPointZ = -spawnRangeZ;
        }
        else
        {
            spawnPointZ = spawnRangeZ;
        }
        Vector3 randomPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0,
            spawnPointZ);

        return randomPosition;
    }

    private int GenerateRandomIndex()
    {
        int randomIndex = Random.Range(0, unitArray.Length);
        
        return randomIndex;
    }
}
