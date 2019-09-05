using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_edge : MonoBehaviour
{
    public bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cat"))
        {
            move = true;
        }
    }
}
