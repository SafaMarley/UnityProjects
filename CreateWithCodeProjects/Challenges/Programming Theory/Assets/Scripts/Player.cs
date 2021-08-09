using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public int health = 25;
    public float playerAngle;
    public float playerRotationSpeed;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z));
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            /*
            Vector3 mousePos = Input.mousePosition;
            Vector3 bulletDirection = (mousePos - gameObject.transform.position);
            Debug.Log("x:" + bulletDirection.x + "y:" + bulletDirection.y + "z" + bulletDirection.z);
            Quaternion rotation = Quaternion.Euler(0, bulletDirection.y, 0);
            */
            /*
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                Vector3 mousePos = raycastHit.point;
                
                Quaternion rotation = Quaternion.Euler(0, mousePos.x, 0);
                Instantiate(bullet, gameObject.transform.position, rotation);
            }
            */
            Instantiate(bullet, gameObject.transform.position, transform.rotation);
        }
    }
}
