using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lian : MonoBehaviour
{
    private Rigidbody2D my_Join;
    void Start()
    {
        my_Join = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cat"))
        {
            Debug.Log("111");
            //my_Join.constraints =~ RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
           my_Join.constraints = RigidbodyConstraints2D.None;
           my_Join.constraints = RigidbodyConstraints2D.FreezeRotation;

          
        }
    }
}
