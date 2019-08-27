using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_move : MonoBehaviour
{
    private Rigidbody2D rig = null;
    public float Force = 75.0f;
    public float Speed = 3.0f;
    private bool JetActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        JetActive = Input.GetButton("Fire1");
    }

    private void FixedUpdate()
    {
        if (JetActive)
        {
            rig.AddForce(new Vector2(0, Force));
        }
        rig.velocity = new Vector2(Speed, rig.velocity.y);
    }
}
