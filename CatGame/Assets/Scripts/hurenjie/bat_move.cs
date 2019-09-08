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
    public float distance = 2.0f;

    private Vector3 mycat;
    // Start is called before the first frame update

    private Transform cat;

    
    void Start()
    {
        //bat_trans = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
        cat = GameObject.FindGameObjectWithTag("cat").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //edge = Edge.GetComponent<bat_edge>().move;
        if (edge == true && transform.position.x - cat.position.x >= distance)
        {
            mycat = GameObject.FindGameObjectWithTag("cat").GetComponent<Transform>().position;
            //rig.transform.Translate(mycat * speed * Time.deltaTime, Space.Self);
            //Vector3 current = new Vector3(transform.position.x, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, mycat, 0.1f);
            //if (transform.position.x - cat.position.x >= distance)
            //{
            //    Move();
            //}
        }
        else if(edge == true && transform.position.x - cat.position.x < distance)
        {
            Move();
            Destroy(gameObject, 1.0f);
        }
    }
    private void Move()
    {
        rig.transform.Translate(Vector2.left * speed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void FixedUpdate()
    {

    }

}
