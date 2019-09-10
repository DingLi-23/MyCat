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

    private GameUIManager m_GameUIManager;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        cat_Transform = GameObject.FindGameObjectWithTag("cat").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        if (cat_Transform.position.y > 0)
        {
            Vector3 nextPos = new Vector3(cat_Transform.position.x + 2, 0, cat_Transform.position.z - 10);
            m_Transform.position = Vector3.Lerp(m_Transform.position, nextPos, Time.deltaTime * 2);
        }
        if (cat_Transform.position.y < -135)
        {
            Vector3 nextPos = new Vector3(this.GetComponent<Transform>().position.x, -135, cat_Transform.position.z - 10);
            m_Transform.position = Vector3.Lerp(m_Transform.position, nextPos, Time.deltaTime * 2);
            m_GameUIManager.ShowOverPanel();
        }
        if (cat_Transform.position.y > -135 && cat_Transform.position.y < 0)
        {
            Vector3 nextPos = new Vector3(cat_Transform.position.x + 2, cat_Transform.position.y, cat_Transform.position.z - 10);
            m_Transform.position = Vector3.Lerp(m_Transform.position, nextPos, Time.deltaTime * 50);
        }
    }
}
