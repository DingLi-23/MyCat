using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 开始界面UI逻辑控制器.
/// </summary>
public class StartUIManager : MonoBehaviour
{

    private GameObject m_StartPanel;  //开始面板.
    private GameObject m_SetingsPanel;//设置面板.

    private GameObject button_Seting; //设置按钮.
    void Start()
    {
        m_StartPanel = GameObject.Find("StartPanel");
        m_SetingsPanel = GameObject.Find("SetingsPanel");
        button_Seting = GameObject.Find("Seting");
        UIEventListener.Get(button_Seting).onClick = SetingButtonClick;

        m_SetingsPanel.SetActive(false);
    }

    /// <summary>
    /// 设置按钮被点击
    /// </summary>
    private void SetingButtonClick(GameObject go)
    {
        Debug.Log("设置按钮被单机");
        //m_SetingsPanel.SetActive(true);
        //m_StartPanel.SetActive(false);
    }


}
