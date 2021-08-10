using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnits : MonoBehaviour
{
    public int health;
    public  int damage;
    public float speed;
    public static bool isGameOver;

    private GameObject[] enemiesAlive;
    private GameObject player;
    private Player playerScript;
    private Rigidbody enemyRb;
    private Vector3 direction;

    private void Start()
    {
        if (!isGameOver)
        {
            tellWhoYouAre();
            player = GameObject.Find("Player");
            playerScript = player.GetComponent<Player>();
            enemyRb = GetComponent<Rigidbody>();

            Vector3 goalLocation = player.transform.position;
            direction = goalLocation - transform.position;
            move();
        }
    }

    public void move()
    {
        if (!isGameOver)
        {
            enemyRb.AddForce(direction.normalized * speed, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dealDamage(damage);
            Destroy(gameObject);
        }
    }
    
    private void dealDamage(int damage)
    {
        //Debug.Log("selam" + damage);
        playerScript.health -= damage;

        if (playerScript.health <= 0)
        {
            gameOver();
        }
    }

    private void gameOver()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemiesAlive)
        {
            Destroy(enemy);
        }
        isGameOver = true;
        player.gameObject.SetActive(false);
        Debug.Log("you lost");
    }
    
    public virtual void tellWhoYouAre()
    {
    }
}