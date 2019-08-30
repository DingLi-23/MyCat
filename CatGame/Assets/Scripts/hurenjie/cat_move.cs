using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_move : MonoBehaviour
{
    private Rigidbody2D rig = null;
    [Tooltip("用于设置主角跳跃施加的力度")]
    public float Force = 75.0f;
    public float JumpHeight = 0.5f;
    private bool JetActive = false;
    public AudioClip crystal1;
    private int count = 0;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameMasonry"))
        {
            //播放吃金币音乐
            AudioSource.PlayClipAtPoint(crystal1, Camera.main.transform.position);
            Destroy(collision.gameObject);
            count++;
        }

    }
}
