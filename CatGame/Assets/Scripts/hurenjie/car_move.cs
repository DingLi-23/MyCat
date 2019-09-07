using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour
{
    private Rigidbody2D car = null;
    [Tooltip("用于设置小车水平速度")]
    public float Speed = 3.0f;

    public bool catCloseCar = false;

    void Start()
    {
        car = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (catCloseCar == true)
        {
            car.velocity = new Vector2(Speed, car.velocity.y);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cat"))
        {
            catCloseCar = true;
        }
        if (collision.gameObject.CompareTag("inverter"))
        {
            {
                Speed = -Speed ;
            }
            if (collision.gameObject.CompareTag("track_edge1"))
            {
                Debug.Log("YESS");
                transform.GetComponent<Collider>().enabled = false;

            }
        }
    }
    
}
