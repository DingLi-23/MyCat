using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主角管理器
/// </summary>
public class CatManager : MonoBehaviour
{
    private GameObject model;
    private GameObject player;

    void Start()
    {
        string cat = PlayerPrefs.GetString("PlayerName");
        model = Resources.Load<GameObject>(cat);
        player = GameObject.Instantiate(model, new Vector3(1,3,0), Quaternion.identity);
        player.AddComponent<cat_move>();
        player.tag = "cat";

        player.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0);
    }
}
