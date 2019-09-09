using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endforcamera : MonoBehaviour
{
    public GameObject Endc;
    // Start is called before the first frame update
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
