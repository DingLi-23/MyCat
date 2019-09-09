using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 商城Item控制器.
/// </summary>
public class ShopItemUI : MonoBehaviour
{
    private Transform m_Transform;

    private UILabel ui_Price;
    private GameObject catParent;

    private GameObject buyButton;
    private GameObject itemState;//商品状态.

    public int itemPrice; //价格.
    public int itemId;    //商品ID.

    void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();

        ui_Price = m_Transform.Find("BuyButton/Price").GetComponent<UILabel>();
        catParent = m_Transform.Find("Model").gameObject;
        itemState = m_Transform.Find("BuyButton").gameObject;

        buyButton = m_Transform.Find("BuyButton/Bg").gameObject;
        UIEventListener.Get(buyButton).onClick = BuyButtonClick;
    }

    /// <summary>
    /// 给商品的UI赋值.
    /// </summary>
    /// <param name="price"></param>
    public void SetUIValue(string id,string price,GameObject model,int state)
    {
        //给UI元素赋值.
        ui_Price.text = price;

        itemPrice = int.Parse(price);
        itemId = int.Parse(id);

        //判断状态.
        if (state == 1)
        {
            itemState.SetActive(false);
        }

        //实例化主角
       GameObject cat = NGUITools.AddChild(catParent, model);
       cat.layer = 8;

       Transform cat_Transform = cat.GetComponent<Transform>();
        //设置猫模型的缩放位置.
        cat_Transform.localScale = new Vector3(60,60,0);
        cat_Transform.localPosition = new Vector3(0, -30, 0);
    }

    /// <summary>
    /// 购买按钮被点击.
    /// </summary>
    /// <param name="go"></param>
    private void BuyButtonClick(GameObject go)
    {
        Debug.Log("购买点击");
        SendMessageUpwards("CalcItemPrice", this);
    }

    public void BuyEnd()
    {
        itemState.SetActive(false);
    }
}
