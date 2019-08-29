using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour
{
    private Rigidbody2D car = null;
    public float Force = 75.0f;

    [Tooltip("用于设置小车水平速度")]
    public float Speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        car.velocity = new Vector2(Speed, car.velocity.y);
    }
}
