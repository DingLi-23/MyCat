using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public Button PhotographTest;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Click_test()
    {
        Debug.Log("截屏");
        Camera camera = GameObject.Find("Camera").gameObject.GetComponent<Camera>();
        int ratio = 2;
        Rect rect = new Rect(0, 0, (int)Screen.width / ratio, (int)Screen.height / ratio);
        Texture2D TT = ScreenShot(camera, rect);
    }

    public Texture2D ScreenShot(Camera camera, Rect rect)
    {
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);
        camera.targetTexture = rt;
        camera.Render();
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();
        camera.targetTexture = null;
        RenderTexture.active = null;
        GameObject.Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        //图片存放路径.
        string filename = Application.dataPath + "/Screenshot.png";
        System.IO.File.WriteAllBytes(filename, bytes);

        UnityEditor.AssetDatabase.Refresh();

        Invoke("CreateImage", 0.5f);
        return screenShot;
    }

    void CreateImage()
    {
        GameObject go = GameObject.Find("Canvas/Image").gameObject;
        GameObject Im = new GameObject("jieping");
        Im.name = "jieping";
        Im.transform.SetParent(go.transform, false);
        Im.AddComponent<Image>();
        Im.GetComponent<Image>().sprite = Resources.Load<Sprite>("/Screenshot.png");
        Im.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        Vector2 v2 = new Vector2((float)(113.8 * 7), (float)(64.2 * 7));
        StartCoroutine(sizeDelta(Im, v2));
    }
    int RemainCount = 0;
    IEnumerator sizeDelta(GameObject go, Vector2 endSize)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.001f);
            if (go.GetComponent<RectTransform>().sizeDelta != endSize)
            {
                go.GetComponent<RectTransform>().sizeDelta = Vector2.MoveTowards(go.GetComponent<RectTransform>().sizeDelta, endSize, 1000 * Time.deltaTime);
            }
            else
            {
                if (RemainCount == 300)
                {
                    go.SetActive(false);
                    RemainCount = 0;
                }
                else
                {
                    go.GetComponent<RectTransform>().sizeDelta = endSize;
                    RemainCount++;
                }
            }
        }
    }
}
