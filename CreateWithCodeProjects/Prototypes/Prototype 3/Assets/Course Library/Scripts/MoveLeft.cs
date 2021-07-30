using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 10;
    public static int score;
    public bool superSpeed;
    

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        addScore();
        if (Input.GetKeyDown(KeyCode.LeftShift) && !playerController.gameOver)
        {
            superSpeed = true;
            moveSpeed *= 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && !playerController.gameOver)
        {
            superSpeed = false;
            moveSpeed /= 2;
        }
        
        if (!playerController.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
    }

    void addScore()
    {
        if (superSpeed)
        {
            score += 2 * (int) Time.time;
        }
        else
        {
            score += (int) Time.time;
        }
    }
}
