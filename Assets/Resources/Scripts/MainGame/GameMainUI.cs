using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainUI : MonoBehaviour {

    //定义委托
    public delegate void PlayerAttributeChanges();
    //定义委托事件
    public event PlayerAttributeChanges change;
     

    void PlayerAttributeChange()
    {
        if (change != null)
        {
            change();
        }
    }
    #region 单例模式
    private static GameMainUI _instance;
    public static GameMainUI Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Canvas").GetComponent<GameMainUI>();
            }
            return _instance;
        }
    }
    #endregion
    public Button KnapsackBtn;  //背包按钮
    public Button chestBtn;     //仓库按钮
    public Button StoreBtn;     //商店按钮
    public Button PlayerHeadBtn;//人物信息按钮

    public Text HPTxt;
    public Text MPTxt;
    public Image HPImage;
    public Image MPImage;

    #region basic property
    private int basicStrength = 10;
    private int basicIntellect = 10;
    private int basicAgility = 10;
    private int basicStamina = 10; 
    private int basicDamage = 10;

    private int _hp;
    private int _mp;
    public int HP
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            PlayerAttributeChange();
        }
    }
    public int MP
    {
        get
        {
            return _mp;
        }
        set
        {
            _mp = value;
            PlayerAttributeChange();
        }
    }

    public int BasicStrength
    {
        get
        {
            return basicStrength;
        }
    }
    public int BasicIntellect
    {
        get
        {
            return basicIntellect;
        }
    }
    public int BasicAgility
    {
        get
        {
            return basicAgility;
        }
    }
    public int BasicStamina
    {
        get
        {
            return basicStamina;
        }
    }
    public int BasicDamage
    {
        get
        {
            return basicDamage;
        }
    }
    #endregion  

    private int coinAmount = 100;//金币
    private Text coinText;

    public int CoinAmount
    {
        get
        {
            return coinAmount;
        }
        set
        {
            coinAmount = value;
            coinText.text = coinAmount.ToString();
        }
    }
    int MaxHP;
    int MaxMP;
    private void Awake()
    {
        coinText = GameObject.Find("Coins").GetComponentInChildren<Text>();
    }
    private void Start()
    {
        HP = 600;
        MP = 800;
        MaxHP = 1200;
        MaxMP = 1000;
        coinText.text = coinAmount.ToString();
        KnapsackBtn.onClick.AddListener(Knapsack.Instance.DisplaySwitch);
        chestBtn.onClick.AddListener(Chest.Instance.DisplaySwitch);
        PlayerHeadBtn.onClick.AddListener(CharacterPanel.Instance.DisplaySwitch);
        StoreBtn.onClick.AddListener(Store.Instance.DisplaySwitch);
        change += DateChange;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            int id = Random.Range(1, 15);
            Knapsack.Instance.StoreItem(id);
        }
        // Debug.Log(CoinAmount);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HP += 5;
        }
    }
    /// <summary>
    /// 消费
    /// </summary>
    public bool ConsumeCoin(int amount)
    {
        if (coinAmount >= amount)
        {
            coinAmount -= amount;
            coinText.text = coinAmount.ToString();
            return true;
        }
        return false;
    }

    /// <summary>
    /// 赚取金币
    /// </summary>
    /// <param name="amount"></param>
    public void EarnCoin(int amount)
    {
        this.coinAmount += amount;
        coinText.text = coinAmount.ToString();
    }


    void DateChange()
    {
        if (HP <= MaxHP&&HP>=0)
        {
            HPTxt.text = HP.ToString() + " / " + MaxHP.ToString();
            HPImage.fillAmount = (float)HP / MaxHP;
        }
        if (MP <= MaxMP&&MP>=0)
        {
            //如果此时HP和MP为Int类型的话,需要转换(做错笔记)
            MPTxt.text = MP.ToString() + " / " + MaxMP.ToString();
            MPImage.fillAmount = (float)MP / MaxMP;
        }
    }

}
