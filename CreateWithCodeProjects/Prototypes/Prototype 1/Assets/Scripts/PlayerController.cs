using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 25.0f;

    void LateUpdate()
    {
        //using the input to move player
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        }
    }
}
