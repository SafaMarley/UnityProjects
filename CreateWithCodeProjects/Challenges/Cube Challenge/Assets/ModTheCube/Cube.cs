using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer renderer;
    public float rotationRange = 20.0f;
    public float positionRange = 3.0f;
    public float[] rotationSpeed = new float[3];
    public float[] colorInformation = new float[4];
    public int randomMultiplier;
    public Color cubeColor;
    
    void Start()
    {
        rotationSpeed[0] = Random.Range(-rotationRange, rotationRange);    //random speed for cube's rotation on x axis
        rotationSpeed[1] = Random.Range(-rotationRange, rotationRange);    //random speed for cube's rotation on y axis
        rotationSpeed[2] = Random.Range(-rotationRange, rotationRange);    //random speed for cube's rotation on z axis

        Vector3 transformVector = new Vector3(Random.Range(-positionRange, positionRange),      //random x location for cube's position
            Random.Range(-positionRange, positionRange),                                        //random y location for cube's position
            Random.Range(-positionRange, positionRange));                                       //random z location for cube's position
           
        colorInformation[0] = Random.Range(0.0f, 1.0f);     //r value for color
        colorInformation[1] = Random.Range(0.0f, 1.0f);     //g value for color
        colorInformation[2] = Random.Range(0.0f, 1.0f);     //b value for color
        colorInformation[3] = 1.0f;                         //a value for color
        
        randomMultiplier = Random.Range(1, 7);          //random multiplier for cube's scale
        
        transform.position = transformVector;
        transform.localScale = Vector3.one * 0.5f * randomMultiplier;
        cubeColor = new Color(colorInformation[0], colorInformation[1], colorInformation[2], colorInformation[3]);
        renderer.material.color = cubeColor;
    }
    
    void Update()
    { 
        transform.Rotate(rotationSpeed[0] * Time.deltaTime, rotationSpeed[0] * Time.deltaTime, rotationSpeed[0] * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.W) && cubeColor.a <= 0.9f)
        {
            cubeColor.a += 0.1f;
            renderer.material.color = cubeColor;
        }
        else if (Input.GetKeyDown(KeyCode.S) && cubeColor.a >= 0.1f)
        {
            cubeColor.a -= 0.1f;
            renderer.material.color = cubeColor;
        }
    }
}
