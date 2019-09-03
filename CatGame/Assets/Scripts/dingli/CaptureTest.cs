using UnityEngine;
using System.Collections;

public class CaptureTest : MonoBehaviour
{
    public Camera gameCamera;
    public Camera bgCamera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

   public void OnClick()
    {
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        CaptureCamera(gameCamera, bgCamera, rect);
    }
    Texture2D CaptureCamera(Camera gameCamera, Camera bgCamera, Rect rect)
    {
        // 创建一个RenderTexture对象,最后的depth得根据要截取的场景的depth最高来定，如果最高是0，那么这里最后的0改成1，保证截取的时候depth大于要截取的所有camera
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);
        // 设置两个camera的targetTexture
        gameCamera.targetTexture = rt;
        bgCamera.targetTexture = rt;
        //注意渲染顺序
        bgCamera.Render();
        gameCamera.Render();

        // 激活这个rt, 并从中中读取像素。
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素
        screenShot.Apply();

        //// 重置相关参数，以使用camera继续在屏幕上显示
        //gameCamera.targetTexture = null;
        //bgCamera.targetTexture = null;
        //RenderTexture.active = null; 
        //GameObject.Destroy(rt);
        // 最后将这些纹理数据，成一个png图片文件
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.dataPath + "/Screenshot.png";
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("截屏了一张照片: {0}", filename));

        return screenShot;
    }
}