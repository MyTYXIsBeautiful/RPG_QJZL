using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Inventory
{
    #region 单例模式
    private static Store _instance;
    public static Store Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("StorePanel").GetComponent<Store>();
            }
            return _instance;
        }
    }
    #endregion

    public int[] itemIdArray;
    private GameMainUI gameMainUI;
    public override void Start()
    {
        base.Start();
        InitShop();
        gameMainUI = GameObject.Find("Canvas").GetComponent<GameMainUI>();
    }
    private void InitShop()
    {
        foreach (int itemId in itemIdArray)
        {
            StoreItem(itemId);
        }
    }
    /// <summary>
    /// 主角购买
    /// </summary>
    /// <param name="item"></param>
    public void BuyItem(Item item)
    {
        bool isSuccess = gameMainUI.ConsumeCoin(item.BuyPrice);
        if (isSuccess)
        {
            Knapsack.Instance.StoreItem(item);
        }
    }
    /// <summary>
    /// 主角出售物品
    /// </summary>
    public void SellItem()
    {
        int sellAmount = 1;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            sellAmount = 1;
        }
        else
        {
            sellAmount = InventoryManager.Instance.PickedItem.Amount;
        }

        int coinAmount = InventoryManager.Instance.PickedItem.Item.SellPrice * sellAmount;
        gameMainUI.EarnCoin(coinAmount);
        InventoryManager.Instance.RemoveItem(sellAmount);
    }
}
