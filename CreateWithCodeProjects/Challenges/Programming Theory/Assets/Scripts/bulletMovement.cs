using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    private float speed = 10f;
    private EnemyUnits enemyUnitScript;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if ((Mathf.Abs(transform.position.z) > 7) || (Mathf.Abs(transform.position.x) > 11))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            Destroy(gameObject);
            enemyUnitScript = other.gameObject.GetComponent<EnemyUnits>();
            enemyUnitScript.health--;
            if (enemyUnitScript.health == 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
