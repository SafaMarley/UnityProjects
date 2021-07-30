using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;
    public float speed = 3f;
    public static Vector3 vectorToPlayer;
    private Vector3 location;
    private Vector3 playersLocation;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        location = transform.position;
        playersLocation = player.transform.position;
        
        vectorToPlayer = (playersLocation - location).normalized;
        enemyRb.AddForce(vectorToPlayer * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
