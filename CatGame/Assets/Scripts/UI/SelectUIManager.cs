using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectUIManager : MonoBehaviour
{
    private GameObject button_Checkpoint1;
    private GameObject button_Checkpoint2;
    private GameObject button_Checkpoint3;

    void Start()
    {
        button_Checkpoint1 = GameObject.Find("Checkpoint1");
        button_Checkpoint2 = GameObject.Find("Checkpoint2");
        button_Checkpoint3 = GameObject.Find("Checkpoint3");

        UIEventListener.Get(button_Checkpoint1).onClick = Checkpoint1ButtonClick;
        UIEventListener.Get(button_Checkpoint2).onClick = Checkpoint2ButtonClick;
        UIEventListener.Get(button_Checkpoint3).onClick = Checkpoint3ButtonClick;
    }

    private void Checkpoint1ButtonClick(GameObject go)
    {
        SceneManager.LoadScene("Game_1_5");
    }
    private void Checkpoint2ButtonClick(GameObject go)
    {
        SceneManager.LoadScene("Game_1_6");
    }
    private void Checkpoint3ButtonClick(GameObject go)
    {
        SceneManager.LoadScene("Game_2_3");
    }
}
