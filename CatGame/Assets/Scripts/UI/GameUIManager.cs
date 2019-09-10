using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏界面UI逻辑控制.
/// </summary>
public class GameUIManager : MonoBehaviour
{
    private GameObject m_GamePanel;
    private GameObject m_OverPanel;
    private GameObject m_SuspendPanel;
    
    private UILabel label_Score; //分数UI.

    private GameObject button_Reset;
    private GameObject button_Suspend;
    private GameObject button_Aging;

    //OverpaneInfo.
    private UILabel DiamondsNu;  

    void Start()
    {
        m_GamePanel = GameObject.Find("GamePanel");
        m_OverPanel = GameObject.Find("OverPanel");
        m_SuspendPanel = GameObject.Find("SuspendPanel");      

        label_Score = GameObject.Find("DiamondsNum1").GetComponent<UILabel>();
        label_Score.text = "0";

        DiamondsNu = GameObject.Find("DiamondsNum2").GetComponent<UILabel>();


        DiamondsNu = GameObject.Find("Diamonds/DiamondsNum2").GetComponent<UILabel>();

        button_Reset = GameObject.Find("Reset");
        UIEventListener.Get(button_Reset).onClick = ResetButtonClick;
        button_Suspend = GameObject.Find("suspend");
        UIEventListener.Get(button_Suspend).onClick = SuspendButtonClick;

        button_Aging = GameObject.Find("aging");
        UIEventListener.Get(button_Suspend).onClick = AgingButtonClick;

        m_OverPanel.SetActive(false);  //结束面板默认隐藏.
        m_SuspendPanel.SetActive(false);
        
    }

    /// <summary>
    /// 更新分数UI显示.
    /// </summary>
    public void UpdateScoreLabel(int score)
    {
        label_Score.text = score.ToString();
    }

    public void ShowOverPanel()
    {
        m_OverPanel.SetActive(true);
        m_GamePanel.SetActive(false);
        SetOverPanelInfo();
    }


    private void ResetButtonClick(GameObject go)
    {
        SceneManager.LoadScene("Start");
    }

    private void SuspendButtonClick(GameObject go)
    {
        Debug.Log("暂停");
        Time.timeScale = 0;
        m_SuspendPanel.SetActive(true);
        m_GamePanel.SetActive(false);
    }

    private void AgingButtonClick(GameObject go)
    {
        Debug.Log("开始");
        Time.timeScale = 1;
        m_SuspendPanel.SetActive(false);
        m_GamePanel.SetActive(true);
    }

    private void SetOverPanelInfo()
    {
        int a = int.Parse(label_Score.text);
        DiamondsNu.text = "+" + a;

        //存储钻石.
        PlayerPrefs.SetInt("MasonryCount", a);
    }

}
