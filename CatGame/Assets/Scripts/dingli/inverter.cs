using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inverter : MonoBehaviour
{
    private Transform cat_Transform;

    void Start()
    {
        cat_Transform = GameObject.FindGameObjectWithTag("cat").GetComponent<Transform>(); 
    }

    void Update()
    { 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("car"))
        {
            cat_Transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
