using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring : MonoBehaviour
{
    private BoxCollider2D m_box;
    void Start()
    {
        m_box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("car"))
        {
            m_box.isTrigger = true;
        }


    }
}
