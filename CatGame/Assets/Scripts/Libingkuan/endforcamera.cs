using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endforcamera : MonoBehaviour
{
    public GameObject c;
    public GameObject Endc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Endc.GetComponent<Endc>().a == 0)
        {
            GetComponent<Animator>().enabled = true;
        }
    }
}
