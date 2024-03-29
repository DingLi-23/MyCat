﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_move : MonoBehaviour
{
    private Rigidbody2D rig = null;
    private SpriteRenderer cat_Sprite = null;
    [Tooltip("用于设置主角跳跃施加的力度")]
    public float Force = 35.0f;
    [Tooltip("猫跳跃高度限制")]
    public float JumpHeight = 0.8f;
    //是否能够跳跃
    
    private float MaxHeightY;
    private bool JetActive = false;

    private bool grounded = false;
    private bool CatDead = false;
    private bool canJump = true;
    private Animator anim = null;

    public AudioClip crystal1;//收集砖石音频
    public AudioClip catdead;//猫死亡音频
    private int rewardNum = 0;

    public bool bat_dead = false;

    public BounceWall bounceWall;
    private GameUIManager m_GameUIManager; 


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        cat_Sprite = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    

        m_GameUIManager = GameObject.Find("UI Root").GetComponent<GameUIManager>();

        
    }

    void Update()
    {
        JetActive = Input.GetButton("Fire1");
        cat_Sprite.flipX = rig.velocity.x < 0 ? true : false; 
    }

    private void FixedUpdate()
    {
        if (transform.position.y >= MaxHeightY)
        {
            canJump = false;
        }
        if (JetActive && canJump)
        {
            rig.AddForce(new Vector2(0, Force));
            anim.SetBool("grounded", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Reward"))
        { 
            //播放吃金币音乐
            AudioSource.PlayClipAtPoint(crystal1, Camera.main.transform.position);
            rewardNum++;
            m_GameUIManager.UpdateScoreLabel(rewardNum); //更新UI分数显示.
            Destroy(collision.gameObject);
           
        }
        if (collision.gameObject.CompareTag("Bat") )
        {
            CatDead = true;
            AudioSource.PlayClipAtPoint(catdead, Camera.main.transform.position);
            //缺少蝙蝠AI以及猫死亡动画
            anim.SetBool("catDead", CatDead);
            Debug.Log("cat is deaded");
            Collider2D c1 = rig.GetComponent<Collider2D>();
            BoxCollider2D c2 = rig.GetComponentInChildren<BoxCollider2D>();
            c1.enabled = false;
            c2.enabled = false;
            rig.constraints = RigidbodyConstraints2D.None;
        }
        if (collision.gameObject.CompareTag("Flame"))
        {
            CatDead = true;
            AudioSource.PlayClipAtPoint(catdead, Camera.main.transform.position);
            anim.SetBool("catDead", CatDead);
            Collider2D c1 = rig.GetComponent<Collider2D>();
            BoxCollider2D c2 = rig.GetComponentInChildren<BoxCollider2D>();
            c1.enabled = false;
            c2.enabled = false;
        }
        if (collision.gameObject.CompareTag("batdead"))
        {
            anim.SetBool("grounded", false);
         
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("car"))
        {
            MaxHeightY = transform.position.y + JumpHeight;
            anim.SetBool("grounded", true);
            canJump = true;
            grounded = true;
        }

        //反弹壁.
        if (collision.gameObject.CompareTag("BounceWall_rigth"))
        {
            if (GameObject.FindGameObjectWithTag("BounceWall_rigth").GetComponent<BounceWall>().Awesome == true)
            {
                rig.velocity = GameObject.FindGameObjectWithTag("BounceWall_rigth").GetComponent<BounceWall>().direction;
            }
            if (GameObject.FindGameObjectWithTag("BounceWall_rigth").GetComponent<BounceWall>().Awesome == false && Input.GetButton("Fire1"))
            {
                rig.velocity = GameObject.FindGameObjectWithTag("BounceWall_rigth").GetComponent<BounceWall>().direction;
            }
        }
        if (collision.gameObject.CompareTag("BounceWall_left"))
        {
            if (GameObject.FindGameObjectWithTag("BounceWall_left").GetComponent<BounceWall>().Awesome == true)
            {
                rig.velocity = GameObject.FindGameObjectWithTag("BounceWall_left").GetComponent<BounceWall>().direction;
            }
            if (GameObject.FindGameObjectWithTag("BounceWall_left").GetComponent<BounceWall>().Awesome == false && Input.GetButton("Fire1"))
            {
                rig.velocity = GameObject.FindGameObjectWithTag("BounceWall_left").GetComponent<BounceWall>().direction;
            }
        }

    }
}
