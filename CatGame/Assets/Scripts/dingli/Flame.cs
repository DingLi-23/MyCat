using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    [Tooltip("圆半径")]
    public float RadiusLength;
    [Tooltip("运动速度")]
    public float AngleSpeed;
    [Tooltip("圆心")]
    public Vector3 CenterPos;

    private float TempAngle;
    private Vector3 PosNew;

    void Start()
    {

    }

    void Update()
    {
        TempAngle += AngleSpeed * Time.deltaTime; 

        PosNew.x = CenterPos.x + Mathf.Cos(TempAngle) * RadiusLength;
        PosNew.y = CenterPos.y + Mathf.Sin(TempAngle) * RadiusLength;
        PosNew.z = transform.localPosition.z;

        transform.localPosition = PosNew;

    }
}
