using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 开始界面UI逻辑控制器.
/// </summary>
public class StartUIManager : MonoBehaviour
{
    private GameObject m_StartPanel;  //开始面板.
    private GameObject m_SetingsPanel;//设置面板.
    private GameObject m_ShoppPanel;  //商店面板.

    private GameObject button_Seting; //设置按钮.
    private GameObject button_Play;   //开始按钮.
    private GameObject button_Shop;   //商店按钮.

    void Start()
    {
        m_StartPanel = GameObject.Find("StartPanel");
        m_SetingsPanel = GameObject.Find("SetingsPanel");
        m_ShoppPanel = GameObject.Find("ShoppPanel");

        button_Seting = GameObject.Find("Seting");
        button_Play = GameObject.Find("Play");
        button_Shop = GameObject.Find("Shop");

        UIEventListener.Get(button_Seting).onClick = SetingButtonClick;   
        UIEventListener.Get(button_Play).onClick = PlayButtonClick;
        UIEventListener.Get(button_Shop).onClick = ShopButtonClick;

        m_SetingsPanel.SetActive(false);  //默认隐藏设置面板.
        m_ShoppPanel.SetActive(false);    //默认隐藏商店面板.
    }

    /// <summary>
    /// 设置按钮被点击
    /// </summary>
    private void SetingButtonClick(GameObject go)
    {
        //首先判断设置面板是否已经显示，如果已经显示，就不在进行该逻辑.
        if (m_SetingsPanel.activeSelf == false)
        {
            Debug.Log("设置按钮被单机");
            m_SetingsPanel.SetActive(true);
            m_StartPanel.SetActive(false);
        }       
    }

    private void ShopButtonClick(GameObject go)
    {
        //首先判断商城面板是否已经显示，如果已经显示，就不在进行该逻辑.
        if (m_ShoppPanel.activeSelf == false)
        {
            Debug.Log("商城按钮被单机");
            m_ShoppPanel.SetActive(true);
            m_StartPanel.SetActive(false);
        }  
    }

    /// <summary>
    /// 开始按钮被点击.
    /// </summary>
    /// <param name="go"></param>
    private void PlayButtonClick(GameObject go)
    {
        //场景跳转.
        SceneManager.LoadScene("Select");
    }

}
