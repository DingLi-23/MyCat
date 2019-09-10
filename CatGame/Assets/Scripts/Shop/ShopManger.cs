using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 商城模块总控制器.
/// </summary>
public class ShopManger : MonoBehaviour
{
    private ShopData shopData;

    //XML路径.
    private string xmlPath = "Assets/Datas/ShopData.xml";
    //XML存档路径.
    private string savePath = "Assets/Datas/SaveData.xml";

    private GameObject ui_ShopItem;

    //左右按钮.
    private GameObject leftButton;
    private GameObject rightButton;
    private GameObject button_Play;   //开始按钮.

    //商城UI集合
    private List<GameObject> shopUI = new List<GameObject>();

    //显示UI索引.
    private int index = 0;

    private UILabel masonryNums;

    void Start()
    {
        shopData = new ShopData();

        //加载XML.
        shopData.ReadXmlByPath(xmlPath);
        shopData.ReadMasonryandshopState(savePath);
        
        //shopData.shopList:

        Debug.Log(shopData.masonryCount);

        for (int i = 0; i < shopData.shopState.Count; i++)
        {
            Debug.Log(shopData.shopState[i]);
        }

        ui_ShopItem = Resources.Load<GameObject>("UI/ShopItem");

        //左右按钮事件.
        leftButton = GameObject.Find("LeftButton");
        rightButton = GameObject.Find("RightButton");
        button_Play = GameObject.Find("Play");
        UIEventListener.Get(leftButton).onClick = LeftButtonClick;
        UIEventListener.Get(rightButton).onClick = RightButtonClick;
        UIEventListener.Get(button_Play).onClick = PlayButtonClick;

        //UI与xml数据的同步.
        masonryNums = GameObject.Find("Masonry/MasonryNum").GetComponent<UILabel>();
        //UpdateUI();

        //读取PlayerPerfs中的钻石数.
        int tempMasonry = PlayerPrefs.GetInt("MasonryCount", 0);
        if (tempMasonry  > 0)
        {
            int masonry = shopData.masonryCount + tempMasonry;
            //更新UI
            UpdateUIMasonry(masonry);           
            //更新XML中的数据.
            shopData.UpdateXMLData(savePath, "MasonryCount", masonry.ToString());
            //清空PlayerPrefs
            PlayerPrefs.SetInt("MasonryCount", 0);
        }
        else
        {
            //更新UI.
            UpdateUIMasonry(shopData.masonryCount);
        }

        SetPlayerInfo(shopData.shopList[0].Model);

        CreateAllShopUI();
    }

    private void UpdateUIMasonry(int masonry)
    {
        masonryNums.text = masonry.ToString();
    }

    /// <summary>
    /// 更新UI数据显示.
    /// </summary>
    private void UpdateUI()
    {
        masonryNums.text = shopData.masonryCount.ToString();
    }
    /// <summary>
    /// 创建商城模块中的商品
    /// </summary>
    private void CreateAllShopUI()
    {
        for (int i = 0; i < shopData.shopList.Count;i++)
        {
            //实例化商品UI.
            GameObject item = NGUITools.AddChild(gameObject, ui_ShopItem);
            //加载对应的猫.
            GameObject cat = Resources.Load<GameObject>(shopData.shopList[i].Model);
            //给商品UI元素赋值.
            item.GetComponent<ShopItemUI>().SetUIValue(shopData.shopList[i].Id,shopData.shopList[i].Price, cat, shopData.shopState[i]);
            //添加UI
            shopUI.Add(item);
        }
        //隐藏UI.
        ShopUIHideAndShow(index);
    }

    private void LeftButtonClick(GameObject go)
    {
        if (index > 0)
        {
          index--;
          int temp = shopData.shopState[index];
          SetPlayButtonState(temp);
          SetPlayerInfo(shopData.shopList[index].Model);
          ShopUIHideAndShow(index);
        }
    }

    private void RightButtonClick(GameObject go)
    {
        if (index < shopUI.Count - 1)
        {
          index++;
          int temp = shopData.shopState[index];
          SetPlayButtonState(temp);
          SetPlayerInfo(shopData.shopList[index].Model);
          ShopUIHideAndShow(index);            
        }
    }

    private void PlayButtonClick(GameObject go)
    {
        //场景跳转.
        SceneManager.LoadScene("Select");
    }
    public void SetPlayButtonState(int state)
    {
        if (state == 1)
        {
          button_Play.SetActive(true);            
        }
        else
        {
            button_Play.SetActive(false);
        }
    }

    /// <summary>
    /// 商城UI的显示和隐藏.
    /// </summary>
    private void ShopUIHideAndShow(int index)
    {
        for (int i = 0; i < shopUI.Count; i++)
        {
            shopUI[i].SetActive(false);
        }

        shopUI[index].SetActive(true);
    }

    private void CalcItemPrice(ShopItemUI item)
    {
        if (shopData.masonryCount >= item.itemPrice)
        {
            Debug.Log("购买成功");
            //隐藏购买.
            item.BuyEnd();                           //隐藏购买UI按钮.
            shopData.masonryCount -= item.itemPrice; //减去已经消耗的钻石.
            UpdateUI();                              //更新UI显示.
            shopData.UpdateXMLData(savePath, "MasonryCount",shopData.masonryCount.ToString()); //更新XML的钻石的数量.
            shopData.UpdateXMLData(savePath, "ID" + item.itemId, "1");                         //更新商品状态.
        }
        else
        {
            Debug.Log("购买失败，钻石不够");
        }
    }

    /// <summary>
    /// 存储角色信息到PlayerPrefs
    /// </summary>
    /// <param name="name"></param>
    private void SetPlayerInfo(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
    }
}
