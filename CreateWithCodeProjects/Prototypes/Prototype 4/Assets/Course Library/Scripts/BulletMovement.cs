using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    /*    if (Mathf.Abs(transform.position.z) > 20)
        {
            Destroy(gameObject);
        }
        else if (Mathf.Abs(transform.position.x) > 10)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
