using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inverter : MonoBehaviour
{
    private Transform Cat;

    void Start()
    {
        Cat = GameObject.Find("cat").GetComponent<Transform>(); 
    }

    void Update()
    { 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("car"))
        {
            Cat.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
