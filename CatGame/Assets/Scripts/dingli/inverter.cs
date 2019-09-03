using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inverter : MonoBehaviour
{
    private Transform Cat;
    private Rigidbody2D Car_Move;

    void Start()
    {
        Cat = GameObject.Find("cat").GetComponent<Transform>(); 
    }

    void Update()
    { 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Change();
    }
    private void Change(){
          if (GameObject.FindGameObjectWithTag("car"))
         {
             Cat.eulerAngles = new Vector3(0, 180, 0);         
         }
    }

}
