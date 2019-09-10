/// <summary>
/// Shop物品Item实体类.
/// </summary>
public class ShopItem {
    private string model;
    private string price;
    private string id;

    public ShopItem(string model,string price,string id)
    {
        this.model = model;
        this.price = price;
        this.id = id;
    }
    public string Model
    {
        get { return model; }
        set { model = value;}
    }

    public string Price
    {
        get { return price; }
        set { price = value; }
    }
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public override string ToString()
    {
        return string.Format("model:{0},price:{1}", model, price); ;
    }
}
