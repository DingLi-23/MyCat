using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class floorPush : MonoBehaviour
{
    public int a = 0;
    public Sprite red;
    public Sprite green;
    public GameObject FireOff; 
    public enum Switchcontrol
    {
        FireOff,
        OpenGate
    }

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
        if (collision.gameObject.CompareTag("cat"))
        {
            GetComponent<SpriteRenderer>().sprite = green;
            a = 1;
        }
    }
}

