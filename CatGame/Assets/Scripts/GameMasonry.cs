using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasonry : MonoBehaviour
{
    public GameObject GAMEmasonry;
    // Start is called before the first frame update
    void Start()
    {
        GAMEmasonry.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rig = transform.GetComponent<Rigidbody2D>();
        Instantiate(GAMEmasonry, transform.position, Quaternion.identity);
    }
}
