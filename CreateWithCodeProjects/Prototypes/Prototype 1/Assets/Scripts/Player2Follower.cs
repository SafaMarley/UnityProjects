using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Follower : MonoBehaviour
{
    public GameObject player;
    private bool view = true;
    private Vector3 cameraOffsetTps = new Vector3(0, 5, -8);
    private Vector3 cameraOffsetFps = new Vector3(0, 2, 3);
    
    void LateUpdate()
    {
        if (view)
        {
            transform.position = player.transform.position + cameraOffsetTps;
        }
        else
        {
            transform.position = player.transform.position + cameraOffsetFps;
        }
        
        if (Input.GetKeyUp("n"))
        {
            if (view)
            {
                view = false;
            }
            else
            {
                view = true;
            }
        }
    }
}
