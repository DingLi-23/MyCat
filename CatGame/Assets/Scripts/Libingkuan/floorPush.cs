using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Sprite PlaySprite;
    public Sprite PauseSprite;

    private bool paused = false;
    public Button BtnPlayOrPause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BtnPlayOrPause.image.sprite = !paused ? PauseSprite : PlaySprite;
    }
}
