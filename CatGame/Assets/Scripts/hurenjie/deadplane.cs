using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadplane : MonoBehaviour
{
    private Rigidbody2D rig = null;
    public bool batdead = false;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("catCheck"))
        {
            Collider2D deadPlane = GetComponent<BoxCollider2D>();
            Collider2D bat = rig.GetComponentInParent<PolygonCollider2D>();
            batdead = true;
            deadPlane.enabled = false;
            bat.enabled = false ;
            Destroy(gameObject, 1.0f);
            Debug.Log("batdead1");
        }
    }
}
