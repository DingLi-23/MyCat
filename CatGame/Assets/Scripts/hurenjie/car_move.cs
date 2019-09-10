using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour
{
    private Rigidbody2D car = null;
    [Tooltip("用于设置小车水平速度")]
    public float Speed = 3.0f;

    public bool catCloseCar = false;

    public Collider2D[] wheel = null;
    private Animator anim;
    void Start()
    {
        car = GetComponent<Rigidbody2D>();
        wheel = car.GetComponentsInChildren<Collider2D>();
        anim = GetComponent<Animator>();
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
            car.constraints = RigidbodyConstraints2D.None;
            catCloseCar = true;
            anim.SetBool("CanRun",catCloseCar);
        }
        if (collision.gameObject.CompareTag("inverter"))
        {
            {
                Speed = -Speed ;
            }
        }
    }


}
