using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory : MonoBehaviour
{
    // Start is called before the first frame update
    public float Destroy_Time = 2.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, Destroy_Time);

    }
}
