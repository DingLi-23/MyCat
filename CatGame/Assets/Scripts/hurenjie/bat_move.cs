using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat_move : MonoBehaviour
{
    //private Transform bat_trans;
    private Rigidbody2D rig;
    [Tooltip("蝙蝠飞行速度")]
    public float speed = 4.0f;
    public GameObject Edge;
    public bool edge ;

    private Vector3 mycat;
    // Start is called before the first frame update

    
    void Start()
    {
        //bat_trans = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        edge = Edge.GetComponent<bat_edge>().move;
        if (edge==true)
        {
            mycat = GameObject.FindGameObjectWithTag("cat").GetComponent<Transform>().position;
            //rig.transform.Translate(mycat * speed * Time.deltaTime, Space.Self);
            //Vector3 current = new Vector3(transform.position.x, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, mycat, 0.5f);
            //Move();
        }
        
    }
    private void Move()
    {
        //rig.transform.Translate(Vector2.left * speed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void FixedUpdate()
    {

    }

}
