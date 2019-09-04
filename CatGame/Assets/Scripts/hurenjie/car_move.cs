using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour
{
    private Rigidbody2D car = null;
 
    [Tooltip("用于设置小车水平速度")]
    public float Speed = 3.0f;

    void Start()
    {
        car = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
          
    }

    private void FixedUpdate()
    {   
           car.velocity = new Vector2(Speed, car.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("inverter"))
        {          
            Speed = -Speed;
        }
        if (GameObject.FindGameObjectWithTag("car"))
        {
            
        }
    }
}
