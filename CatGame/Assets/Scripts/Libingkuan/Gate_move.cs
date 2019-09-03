using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_move : MonoBehaviour
{
    private int c;
    public Sprite SluiceGate;
    public float speed = 10;
    public GameObject red;
    // Start is called before the first frame update
    void Start()
    {
        c = red.GetComponent<floorPush>().a;
    }

    // Update is called once per frame
    void Update()
    {
        print(c);
        if(c==1)
        {
            GetComponent<Animation>().enabled = true;
            Debug.Log(c);
        }
    }

}
