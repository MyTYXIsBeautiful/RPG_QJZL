using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    #region 单例模式
    private static InventoryManager _instance;

    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                //下面的代码只会执行一次
                _instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            }
            return _instance;
        }
    }
    #endregion

    /// <summary>
    /// 物品信息的列表（集合）
    /// </summary>
    private List<Item> itemList;

    #region toolTip
    private ToolTip toolTip;
    private Vector2 toolTipPosionOffset = new Vector2(10, -10);

    private bool isToolTipShow = false;//表示ToolTip显示还是隐藏
    #endregion

    #region pickedItem
    private ItemUI pickedItem;//鼠标选中的物体

    private bool isPickedItem = false; //当前是否选中物体
    public bool IsPickedItem
    {
        get
        {
            return isPickedItem;
        }
    }
    public ItemUI PickedItem
    {
        get
        {
            return pickedItem;
        }
    }
    #endregion
    private Canvas canvas;



    private void Awake()
    {
        ParseItemJson();
    }

    private void Start()
    {
        toolTip = GameObject.FindObjectOfType<ToolTip>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        pickedItem = GameObject.Find("PickedItem").GetComponent<ItemUI>();
        pickedItem.Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SaveInventory();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            LoadInventory();
        }
        if (isPickedItem)
        {
            //如果我们捡起了物品，我们就要让物品跟随鼠标
            Vector2 position;
            //把屏幕坐标转成RectTransform
            //1.把屏幕坐标转昵称那个Rect的局部坐标
            //3.鼠标坐标(需要转化的坐标)
            //2.如果第一个参数是Canvas的话并且Canvas的模式是OverlAY的时候可以为空
            //4.用out出来,表示转化后的坐标
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            pickedItem.SetLocalPosition(position);
        }else if (isToolTipShow)
        {
            //控制提示面板跟随鼠标
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            toolTip.SetLocalPotion(position + toolTipPosionOffset);
        }

        //物品丢弃的处理
        if (isPickedItem && Input.GetMouseButtonDown(0) && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1) == false)
        {
            isPickedItem = false;
            PickedItem.Hide();
        }
    }
    /// <summary>
    /// 解析物品信息
    /// </summary>
    void ParseItemJson()
    {
        itemList = new List<Item>();
        //文本为在Unity里面是 TextAsset类型
        TextAsset itemText = Resources.Load<TextAsset>("Items");
        string itemsJson = itemText.text;//物品信息的Json格式
        JsonData data = JsonMapper.ToObject(itemsJson);
        for (int i = 0; i < data.Count; i++)
        {
            string typeStr = data[i]["type"].ToString();
            Item.ItemType type = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), typeStr);
            //下面的事解析这个对象里面的公有属性
            int id = int.Parse((data[i]["id"]).ToString());
            string name = data[i]["name"].ToString();
            Item.ItemQuality quality = (Item.ItemQuality)System.Enum.Parse(typeof(Item.ItemQuality), data[i]["quality"].ToString());
            string description = data[i]["description"].ToString();
            int capacity = int.Parse((data[i]["capacity"]).ToString());
            int buyPrice = int.Parse((data[i]["buyPrice"]).ToString());
            int sellPrice = int.Parse((data[i]["sellPrice"]).ToString());
            string sprite = data[i]["sprite"].ToString();

            Item item = null;
            switch (type)
            {
                case Item.ItemType.Consumable:
                    int hp = int.Parse(data[i]["hp"].ToString());
                    int mp = int.Parse(data[i]["mp"].ToString());
                    item = new Consumable(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite, hp, mp);
                    break;
                case Item.ItemType.Equipment:
                    int strength = int.Parse(data[i]["strength"].ToString());
                    int intellect = int.Parse(data[i]["intellect"].ToString());
                    int agility = int.Parse(data[i]["agility"].ToString());
                    int stamina = int.Parse(data[i]["stamina"].ToString());
                    Equipment.EquipmentType equipType = (Equipment.EquipmentType)System.Enum.Parse(typeof(Equipment.EquipmentType), data[i]["equipType"].ToString());
                    item = new Equipment(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite, strength, intellect, agility, stamina, equipType);
                    break;
                case Item.ItemType.Weapon:
                    int damage = int.Parse(data[i]["damage"].ToString());
                    Weapon.WeaponType wpType = (Weapon.WeaponType)System.Enum.Parse(typeof(Weapon.WeaponType), data[i]["weaponType"].ToString());
                    item = new Weapon(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite, damage, wpType);
                    break;
            }

            itemList.Add(item);
           //Debug.Log(item);
        }
    }

    /// <summary>
    /// 根据ID得到物品信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Item  GetItemByID(int id)
    {
        foreach (Item item in itemList)
        {
            if (item.ID == id)
            {
                return item;
            }
        }
        return null;
    }

    /// <summary>
    /// 显示toolTip
    /// </summary>
    /// <param name="content"></param>
    public void ShowToolTip(string content)
    {
        if (this.isPickedItem) return;
        isToolTipShow = true;
        toolTip.Show(content);
    }
    /// <summary>
    /// 隐藏toolTip
    /// </summary>
    public void HideToolTip()
    {
        isToolTipShow = false;
        toolTip.Hide();
    }

    //捡起物品槽指定数量的物品
    public void PickupItem(Item item, int amount)
    {
        PickedItem.SetItem(item, amount);
        isPickedItem = true;

        PickedItem.Show();
        this.toolTip.Hide();
        //如果我们捡起了物品，我们就要让物品跟随鼠标
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
        pickedItem.SetLocalPosition(position);
    }

    /// <summary>  
    /// 从手上拿掉一个物品放在物品槽里面
    /// </summary>
    public void RemoveItem(int amount = 1)
    {
        PickedItem.ReduceAmount(amount);
        if (PickedItem.Amount <= 0)
        {
            isPickedItem = false;
            PickedItem.Hide();
        }
    }
    public void SaveInventory()
    {
        Knapsack.Instance.SaveInventory();
        Chest.Instance.SaveInventory();
        CharacterPanel.Instance.SaveInventory();
        PlayerPrefs.SetInt("CoinAmount", GameObject.Find("Canvas").GetComponent<GameMainUI>().CoinAmount);
    }

    public void LoadInventory()
    {
        Knapsack.Instance.LoadInventory();
        Chest.Instance.LoadInventory();
        CharacterPanel.Instance.LoadInventory();
        if (PlayerPrefs.HasKey("CoinAmount"))
        {
            GameObject.Find("Canvas").GetComponent<GameMainUI>().CoinAmount = PlayerPrefs.GetInt("CoinAmount");
        }
    }

}
