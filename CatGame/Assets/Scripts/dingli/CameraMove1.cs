using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove1 : MonoBehaviour
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
    }
}
