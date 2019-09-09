using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track_edge : MonoBehaviour
{
    private Collider2D []col = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("car"))
        {
            col = collision.gameObject.GetComponentsInChildren<Collider2D>(true);
            foreach (Collider2D c in col)
            {
                c.enabled = false;
            }
        }
    }
}
