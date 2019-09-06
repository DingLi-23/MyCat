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
            GetComponent<AudioSource>().enabled = true;//声音开关选项
            MainCamera.GetComponent<Camera>().orthographicSize = 3;//摄像头缩放
            Debug.Log("3");
        }
    }
}
