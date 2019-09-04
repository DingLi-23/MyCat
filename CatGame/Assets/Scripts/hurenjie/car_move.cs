using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour
{
    private Rigidbody2D car = null;
   // private Transform Cat;
    [Tooltip("用于设置小车水平速度")]
    public float Speed = 3.0f;

    void Start()
    {
        car = GetComponent<Rigidbody2D>();
       // Cat = GameObject.Find("cat").GetComponent<Transform>(); 

    }

    void Update()
    {
        car.velocity = new Vector2(Speed, car.velocity.y);  
    }

    private void FixedUpdate()
    {   
           
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("inverter"))
        {
           // Cat.eulerAngles = new Vector3(0, 180, 0);
            Speed = -Speed;
        }
        if (GameObject.FindGameObjectWithTag("car"))
        {
            
        }
    }
}
