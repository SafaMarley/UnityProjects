using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float range = 13.0f;
    public float verticalLowerBound = 0.0f;
    public float verticalUpperBound = 15.0f;

    public GameObject projectileFood;
    void Update()
    {
        if (transform.position.x < -range)
        {
            transform.position = new Vector3(-range, transform.position.y, transform.position.z);
        }

        if (transform.position.x > range)
        {
            transform.position = new Vector3(range, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if (transform.position.z < verticalLowerBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalLowerBound);
        }

        if (transform.position.z > verticalUpperBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalUpperBound);
        }
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectileFood, transform.position + new Vector3(0, 0, 3), projectileFood.transform.rotation);
        }
    }
}
