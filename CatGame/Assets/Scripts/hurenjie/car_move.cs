using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour
{
    private Rigidbody2D car = null;
    [Tooltip("用于设置小车水平速度")]
    public float Speed = 3.0f;

    public bool catCloseCar = false;

    //判断小车后轮是否到达轨道边缘1
    //public GameObject B;
    //public bool BW;

    //前轮
    //public GameObject A;
    //public bool AW;

    public Collider2D[] wheel = null;
    void Start()
    {
        car = GetComponent<Rigidbody2D>();
        wheel = car.GetComponentsInChildren<Collider2D>();

    }

    void Update()
    {
        //BW = B.GetComponent<B>().A;
        //AW = A.GetComponent<A>().B;
        //if (BW == true)
        //{
        //    transform.GetComponent<BoxCollider2D>().enabled = false;
        //    foreach (Collider2D collider in wheel)
        //    {
        //        collider.enabled = false;
        //    }
        //}
        //if (AW == true)
        //{
        //    transform.GetComponent<BoxCollider2D>().enabled = false;
        //    foreach (Collider2D collider in wheel)
        //    {
        //        collider.enabled = false;
        //    }
        //}
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
        }
        if (collision.gameObject.CompareTag("inverter"))
        {
            {
                Speed = -Speed ;
            }
            //if (collision.gameObject.CompareTag("track_edge1"))
            //{
            //    transform.GetComponent<Collider>().enabled = false;

            //}
        }
    }


}
