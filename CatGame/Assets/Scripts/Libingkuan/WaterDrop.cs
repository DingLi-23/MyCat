using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    private float StartTime = 0;
    private float TimeInterval = 1.5f;
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartTime += Time.deltaTime;
        if(StartTime>=TimeInterval)
        {
            if (water)
            {
                Vector2 newWater =new Vector2(transform.position.x-0.07f, transform.position.y+0.1f);
                Instantiate(water, newWater, Quaternion.identity);
                StartTime = 0;
            }
        }
       
    }
}
