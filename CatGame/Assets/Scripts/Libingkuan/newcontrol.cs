using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hashtable args = new Hashtable();
        args.Add("speed", 3.0f);
        args.Add("path", iTweenPath.GetPath("MyPath"));
        iTween.MoveTo(gameObject, args);
    }
}
