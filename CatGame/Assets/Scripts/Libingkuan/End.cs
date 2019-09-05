using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnIsTriggerEnter(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cat"))
        { 
            GetComponent<AudioSource>().enabled = true;
            MainCamera.GetComponent<Camera>().orthographicSize = 3;
            Debug.Log("3");
        }
    }
}
