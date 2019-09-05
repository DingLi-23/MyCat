using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_move : MonoBehaviour
{
    private Transform bat_trans;
    private Rigidbody2D rig;
    [Tooltip("蝙蝠飞行速度")]
    public float speed = 4.0f;
    private bool CanMove = false;
    // Start is called before the first frame update
    void Start()
    {
        bat_trans = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove == true)
        {
            Move();
        }
        
    }
    private void Move()
    {
        rig.transform.Translate(Vector2.left * speed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cat"))
        {
            CanMove = true;
        }
    }

}
