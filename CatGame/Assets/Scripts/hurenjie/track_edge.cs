using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track_edge : MonoBehaviour
{
    public bool CloseCarCollision = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("track_edge1"))
        {
            CloseCarCollision = true;
        }
    }
}
