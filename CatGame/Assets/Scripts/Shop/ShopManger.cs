using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //商城UI集合
    private List<GameObject> shopUI = new List<GameObject>();

    //显示UI索引.
    private int index = 0;

    //界面UI.
    private UILabel masonryNum;

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
            Debug.Log(shopData.shopList[i]);
        }

        ui_ShopItem = Resources.Load<GameObject>("UI/ShopItem");

        //左右按钮事件.
        leftButton = GameObject.Find("LeftButton");
        rightButton = GameObject.Find("RightButton");
        UIEventListener.Get(leftButton).onClick = LeftButtonClick;
        UIEventListener.Get(rightButton).onClick = RightButtonClick;

        //UI与xml数据的同步.
        masonryNum = GameObject.Find("Masonry/MasonryNum").GetComponent<UILabel>();
        masonryNum.text = shopData.masonryCount.ToString();

        CreateAllShopUI();
    }

    /// <summary>
    /// 创建商城模块中的商品
    /// </summary>
    private void CreateAllShopUI()
    {
        for (int i = 0; i < shopData.shopList.Count; i++)
        {
            //实例化商品UI.
           GameObject item = NGUITools.AddChild(gameObject, ui_ShopItem);
            //加载对应的猫.
           GameObject cat = Resources.Load<GameObject>(shopData.shopList[i].Model);
            //给商品UI元素赋值.
           item.GetComponent<ShopItemUI>().SetUIValue(shopData.shopList[i].Price, cat,shopData.shopState[i]);

           shopUI.Add(item);
        }

        //隐藏UI.
        ShopUIHideAndShow(index);
    }

    private void LeftButtonClick(GameObject go)
    {
        if (index > 0)
        {
            Debug.Log("Left");
          index--;
          ShopUIHideAndShow(index);            
        }

    }

    private void RightButtonClick(GameObject go)
    {
        if (index < shopUI.Count - 1)
        {
          Debug.Log("Right");
          index++;
          ShopUIHideAndShow(index);            
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
}
