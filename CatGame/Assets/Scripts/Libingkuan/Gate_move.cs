﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_move : MonoBehaviour
{
    public Sprite SluiceGate;
    public float speed = 10;
    public GameObject red;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(red.GetComponent<floorPush>().a == 1)
        {
            GetComponent<Animator>().enabled = true;
        }
    }

}
