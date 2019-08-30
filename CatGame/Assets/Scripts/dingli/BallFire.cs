using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFire : MonoBehaviour
{
    private Transform ball;
    public float speed = 5.0f;
    public bool moveToUp = true;

    void Start()
    {
        ball = this.transform;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (ball.position.y <= -3 && moveToUp)
        {
            moveToUp  = false;

        }
        else if (ball.position.y >= 3 && !moveToUp)
            moveToUp = true;

        ball.position += (moveToUp ? Vector3.down : Vector3.up) * Time.deltaTime * speed;
    }
}
