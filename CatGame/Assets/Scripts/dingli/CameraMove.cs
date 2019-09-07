using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Keyingwave;
    private Transform m_Transform;
    private Transform cat_Transform;

    public float StartTime;
    public float EndTime;
    private float time;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        cat_Transform = GameObject.FindGameObjectWithTag("cat").GetComponent<Transform>();

    }

    void Update()
    {
        m_Transform.position = cat_Transform.position + new Vector3(2,0,-10);
        if (Input.GetButton("Fire1"))
        {
            createKW();
        }
    }
    void FixedUpdate ()
    {
        time++;
        if (this.GetComponent<Camera>().orthographicSize >= 2 && StartTime <= time && time <= EndTime)
        {
            this.GetComponent<Camera>().orthographicSize -= 0.04f;
        }
        else if (this.GetComponent<Camera>().orthographicSize <= 5 && time >= EndTime)
        {
            this.GetComponent<Camera>().orthographicSize += 0.04f;
        } 
    }
    private void createKW()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 mp = Input.mousePosition;
            Vector3 keyW = Camera.main.ScreenToWorldPoint(mp);
            Vector3 newW = new Vector3(keyW.x, keyW.y, 0);
            GameObject KW = Instantiate(Keyingwave, newW, Quaternion.identity);
        }
    }
}
