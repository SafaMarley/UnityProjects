using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 25.0f;

    void LateUpdate()
    {
        //using the input to move player
        if (Input.GetKey("up"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        }
    }
}
