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
    
    private UILabel label_Score; //分数UI.

    private GameObject button_Reset; 

    void Start()
    {
        m_GamePanel = GameObject.Find("GamePanel");
        m_OverPanel = GameObject.Find("OverPanel");

        label_Score = GameObject.Find("DiamondsNum1").GetComponent<UILabel>();
        label_Score.text = "0";

        button_Reset = GameObject.Find("Reset");
        UIEventListener.Get(button_Reset).onClick = ResetButtonClick;

        m_OverPanel.SetActive(false);  //结束面板默认隐藏.
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
    }

    private void ResetButtonClick(GameObject go)
    {
        SceneManager.LoadScene("Start");
    }
}
