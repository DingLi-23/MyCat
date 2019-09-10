using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Keyingwave;
    private Transform m_Transform;
    private Transform cat_Transform;

    private GameUIManager m_GameUIManager;  

    public float StartTime;
    public float EndTime;
    private float time;

    private Vector3 normalPos;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        cat_Transform = GameObject.FindGameObjectWithTag("cat").GetComponent<Transform>();
        normalPos = m_Transform.position;
        m_GameUIManager = GameObject.Find("UI Root").GetComponent<GameUIManager>();
    }

    void Update()
    {       
        createKW();
        //if (m_Transform.position.y < -5)
        //{
        //    m_GameUIManager.ShowOverPanel();
        //    m_Transform.position = this.GetComponent<Transform>().position;
        //}
    }

    void LateUpdate()
    {
        if (cat_Transform.position.y > 5){
            Vector3 nextPos = new Vector3(cat_Transform.position.x + 2, 5, cat_Transform.position.z - 10);
            m_Transform.position = Vector3.Lerp(m_Transform.position, nextPos,Time.deltaTime * 2);
        }
        if (cat_Transform.position.y < -7){
            Vector3 nextPos = new Vector3(this.GetComponent<Transform>().position.x, -6, cat_Transform.position.z - 10);
            m_Transform.position = Vector3.Lerp(m_Transform.position, nextPos, Time.deltaTime * 2);
            m_GameUIManager.ShowOverPanel();
        }
        if (cat_Transform.position.y > -7 && cat_Transform.position.y < 5){
            Vector3 nextPos = new Vector3(cat_Transform.position.x + 2, cat_Transform.position.y, cat_Transform.position.z - 10);
            m_Transform.position = Vector3.Lerp(m_Transform.position, nextPos, Time.deltaTime);
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
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mp = Input.mousePosition;
            Vector3 keyW = Camera.main.ScreenToWorldPoint(mp);
            Vector3 newW = new Vector3(keyW.x, keyW.y, 0);
            GameObject KW = Instantiate(Keyingwave, newW, Quaternion.identity);
        }
    }
}
