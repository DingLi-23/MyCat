using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadplane : MonoBehaviour
{
    private Rigidbody2D cat;
    public bool batdead = false;
    public float catBounForce_x = 120.0f;
    public float catBounForce_y = 120.0f;
    // Start is called before the first frame update
    void Start()
    {
        cat = GameObject.FindGameObjectWithTag("cat").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D rig = transform.GetComponentInParent<Collider2D>();
        if (collision.gameObject.CompareTag("cat"))
        {
            BoxCollider2D deadPlane = GetComponent<BoxCollider2D>();
            batdead = true;
            cat.AddForce(new Vector2(catBounForce_x, catBounForce_y));
            deadPlane.enabled = false;
            rig.enabled = false;
            //bat.enabled = false ;
            Destroy(gameObject, 1.0f);
        }
    }
}
