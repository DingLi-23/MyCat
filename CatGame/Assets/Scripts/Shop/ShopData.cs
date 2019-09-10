using System.Collections;
using System.Collections.Generic;
using System.Xml;

/// <summary>
/// 商城功能模块数据操作.
/// </summary>
public class ShopData
{
    //用于存储XML数据的实体集合.
    public List<ShopItem> shopList = new List<ShopItem>();

    //商品购买状态集合.
    public List<int> shopState = new List<int>();

    //钻石数.
    public int masonryCount = 0;

    public void ReadXmlByPath(string path)
    {
       XmlDocument doc = new XmlDocument();
       doc.Load(path);
       XmlNode root = doc.SelectSingleNode("Shop");
       XmlNodeList nodeLis = root.ChildNodes;
       foreach  (XmlNode node in nodeLis)
       {
           string model = node.ChildNodes[0].InnerText;
           string price = node.ChildNodes[1].InnerText;
           string id = node.ChildNodes[2].InnerText;

           //存储到List实体集合中.
           ShopItem item = new ShopItem(model,price,id);
           shopList.Add(item);
       }
    }
    /// <summary>
    /// 读取钻石数.
    /// </summary>
    public void ReadMasonryandshopState(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("SaveData");
        XmlNodeList nodeLis = root.ChildNodes;

        masonryCount = int.Parse(nodeLis[0].InnerText);

        //读取商品的购买状态.
        for (int i = 1; i < 4; i++)
        {
            shopState.Add(int.Parse(nodeLis[i].InnerText));
        }
    }

    /// <summary>
    /// 更新XML.
    /// </summary>
    /// <param name="?"></param>
    public void UpdateXMLData(string path,string key,string value)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("SaveData");
        XmlNodeList nodeList = root.ChildNodes;

        foreach (XmlNode node in nodeList)
        {
            if (node.Name == key)
            {
                node.InnerText = value;
                doc.Save(path);
            }
        }
    }
}
