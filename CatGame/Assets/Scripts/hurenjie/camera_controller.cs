using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public GameObject Keyingwave;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(KW, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            createKW();
        }
    }
    private void createKW()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 mp = Input.mousePosition;
            Vector3 keyW = Camera.main.ScreenToWorldPoint(mp);
            Vector3 newW = new Vector3(keyW.x, keyW.y, 0);
            GameObject KW = Instantiate(Keyingwave, newW, Quaternion.identity);
        }
    }
}
