using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles = new GameObject[3];
    private Vector3 obstaclePosition = new Vector3(20, 0, 0);
    private float startDelay = 5.0f;
    private float repeatRate = 2.0f;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerController.gameOver == false)
        {
            int randomIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randomIndex], obstaclePosition, obstacles[randomIndex].transform.rotation);
        }
    }
}
