using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnRangeX = 12.5f;
    public float spawnRangeLower = 0.0f;
    public float spawnRangeUpper = 9.0f;
    public float spawnPositionX = 25.0f;
    public float spawnPositionZ = 20.0f;
    private float startDelay = 3;
    private float repeatRate = 1;
    
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, repeatRate);
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);
        Vector3 spawnPositionR = new Vector3(spawnPositionX, 0, Random.Range(spawnRangeLower, spawnRangeUpper));
        Vector3 spawnPositionL = new Vector3(-spawnPositionX, 0, Random.Range(spawnRangeLower, spawnRangeUpper));
        GameObject animal = animalPrefabs[animalIndex];
        Instantiate(animal, spawnPosition, animalPrefabs[animalIndex].transform.rotation);
        Vector3 rotationHolder = animal.transform.eulerAngles;
        animal.transform.eulerAngles = new Vector3(animal.transform.eulerAngles.x, animal.transform.eulerAngles.y - 90, animal.transform.eulerAngles.z); 
        Instantiate(animal, spawnPositionL, animalPrefabs[animalIndex].transform.rotation);
        animal.transform.eulerAngles = new Vector3(animal.transform.eulerAngles.x, animal.transform.eulerAngles.y + 180, animal.transform.eulerAngles.z); 
        Instantiate(animal, spawnPositionR, animalPrefabs[animalIndex].transform.rotation);
        animal.transform.eulerAngles = rotationHolder;
    }
}
