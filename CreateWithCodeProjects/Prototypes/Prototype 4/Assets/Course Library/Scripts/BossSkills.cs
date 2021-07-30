using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkills : MonoBehaviour
{
    private float spawnStartDelay = 2f;
    private float spawnRepeatDelay = 4f;

    public GameObject miniBoss;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("miniBossSpawner", spawnStartDelay, spawnRepeatDelay);
    }

    void miniBossSpawner()
    {
        Instantiate(miniBoss, (transform.position + new Vector3(0, 0, -3)), miniBoss.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
