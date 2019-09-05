using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : MonoBehaviour
{
    public bool Awesome;
    public Vector2 direction;

    private Rigidbody2D Cat;
    void Start()
    {
        Cat = GameObject.Find("cat").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

     public void ReverseMove()
     {
             if (Awesome == true)
             { 
                Cat.velocity = direction;
             }
             else if (Awesome == false && Input.GetButton("Fire1"))
             {
                 Cat.velocity = direction;
             }
     }
}
