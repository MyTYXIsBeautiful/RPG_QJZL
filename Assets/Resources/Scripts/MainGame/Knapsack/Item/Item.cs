using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 物品基类
/// </summary>
public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }  //类型
    public ItemQuality Quality { get; set; }    //品质
    public string Description { get; set; } //描述
    public int Capacity { get; set; }       //容量
    public int BuyPrice { get; set; }   //买入价格
    public int SellPrice { get; set; }  //卖出价格
    public string Sprite { get; set; }  //图片路径

    //构造
    public Item(int id, string name, ItemType type, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.Quality = quality;
        this.Description = des;
        this.Capacity = capacity;
        this.BuyPrice = buyPrice;
        this.SellPrice = sellPrice;
        this.Sprite = sprite;
    }




    /// <summary>
    /// 装备类型
    /// </summary>
    public enum ItemType
    {
        Consumable,     //消耗品
        Equipment,      //装备
        Weapon,         //武器

    }
    /// <summary>
    /// 品质
    /// </summary>
    public enum ItemQuality
    {
        Common, //一般
        Uncommon,   //罕见
        Rare,       //稀有
        Epic,       //史诗
        Legendary,  //传说
        Artifact    //神器
    }


    public virtual  string GetToolTipText()
    {
        string color = "";
        switch (Quality)
        {
            case ItemQuality.Common:
                color = "white";
                break;
            case ItemQuality.Uncommon:
                color = "lime";
                break;
            case ItemQuality.Rare:
                color = "navy";
                break;
            case ItemQuality.Epic:
                color = "magenta";
                break;
            case ItemQuality.Legendary:
                color = "orange";
                break;
            case ItemQuality.Artifact:
                color = "red";
                break;
        }
        string text = string.Format("<color={4}>{0}</color>\n<size=20><color=green>购买价格：{1} 出售价格：{2}</color></size>\n<color=yellow><size=20>{3}</size></color>", Name, BuyPrice, SellPrice, Description, color);

        return text;
    }

     

}
