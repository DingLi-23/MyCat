using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Cat;
    public float StartTime;
    public float EndTime;
    private float time;
    private float distanceX;
    private float distanceY;
    void Start()
    {
        distanceX = transform.position.x - Cat.position.x;
        distanceY = transform.position.y - Cat.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(
            Cat.position.x + distanceX,
            Cat.position.y + distanceY,
            transform.position.z);     
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
}
