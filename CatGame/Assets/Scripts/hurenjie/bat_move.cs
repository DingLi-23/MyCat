using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_move : MonoBehaviour
{
    private Transform bat_trans;
    private Rigidbody2D rig;
    [Tooltip("蝙蝠飞行速度")]
    public float speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        bat_trans = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        //使用键盘控制蝙蝠移动
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //Vector3 dir = new Vector3(h, 0, v);
        //rig.MovePosition(bat_trans.position + dir * 0.2f);
        rig.transform.Translate(Vector2.left * speed * Time.deltaTime, Space.Self);
    }

}
