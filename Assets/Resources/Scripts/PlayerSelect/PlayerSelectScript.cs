using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerSelectScript : MonoBehaviour {

    #region 单例模式
    private static PlayerSelectScript _instance;

    public static PlayerSelectScript Instance
    {
        get
        {
            if (_instance == null)
            {
                //下面的代码只会执行一次
                _instance = GameObject.Find("BG").GetComponent<PlayerSelectScript>();
            }
            return _instance;
        }
    }
    #endregion
    public GameObject PlayerOption; //角色选择界面
    public GameObject PlzyerAffirm; //角色框界面

    public Button StartGameBtn; //开始游戏按钮
    public Button CreateCikeBtn;    //刺客创建按钮
    public Button CreateFashiBtn;   //法师创建按钮
    public Button CreateKnightBtn;  //战士创建按钮

    public Button RoleBox1Btn;  //角色框1Btn;
    public Text RoleBox1TXT;    //角色框1提示文本

    public GameObject RoleBox1; //角色框1
    public GameObject RoleBox2; //角色框2
    public GameObject RoleBox3; //角色框3

    


    public InputField CikeRoleID; //角色ID
    public InputField FashiRoleID; //角色ID
    public InputField KnightRoleID; //角色ID

    public Button CreateCharacterBtn;    //创建角色按钮

    public bool IsDOTween = false;

    int count = 0;
    void Start ()
    {
        CreateCikeBtn.onClick.AddListener(CikeSelectRole);
        CreateFashiBtn.onClick.AddListener(FaShiSelectRole);
        CreateKnightBtn.onClick.AddListener(KnightSelectRole);
        CreateCharacterBtn.onClick.AddListener(CreateCharacter);
        RoleBox1Btn.onClick.AddListener(() =>
        {
            count++;
            if (count == 1)
            {
                RoleBox1TXT.gameObject.SetActive(true);
            }
            if (count == 2)
            {
                count = 0;
                SceneManager.LoadSceneAsync(ConstScript.loadingScene);
            }
        });
    }
	
    /// <summary>
    ///  刺客角色选择方法
    /// </summary>
     void CikeSelectRole()
    {
        if (CikeRoleID.text != "")
        {
            PlayerOption.SetActive(false);
            PlzyerAffirm.SetActive(true);
            if(RoleBox1.transform.GetChild(0).gameObject.activeSelf == false&& RoleBox1.transform.GetChild(1).gameObject.activeSelf == false&& RoleBox1.transform.GetChild(2).gameObject.activeSelf == false)
            {
                RoleBox1.transform.GetChild(0).gameObject.SetActive(true);
                RoleBox1.transform.GetChild(3).gameObject.GetComponent<Text>().text = CikeRoleID.text;
            }
            else if (RoleBox2.transform.GetChild(0).gameObject.activeSelf == false && RoleBox2.transform.GetChild(1).gameObject.activeSelf == false && RoleBox2.transform.GetChild(2).gameObject.activeSelf == false)
            {
                RoleBox2.transform.GetChild(0).gameObject.SetActive(true);
                RoleBox2.transform.GetChild(3).gameObject.GetComponent<Text>().text = CikeRoleID.text;
            }else if (RoleBox3.transform.GetChild(0).gameObject.activeSelf == false && RoleBox3.transform.GetChild(1).gameObject.activeSelf == false && RoleBox3.transform.GetChild(2).gameObject.activeSelf == false)
            {
                RoleBox3.transform.GetChild(0).gameObject.SetActive(true);
                RoleBox3.transform.GetChild(3).gameObject.GetComponent<Text>().text = CikeRoleID.text;
            }else
            {
                return;
            }
        }
        CikeRoleID.text = "";
    }
    /// <summary>
    /// 法师角色选择方法
    /// </summary>
    void FaShiSelectRole()
    {
        if (FashiRoleID.text != "")
        {
            PlayerOption.SetActive(false);
            PlzyerAffirm.SetActive(true);
            if (RoleBox1.transform.GetChild(0).gameObject.activeSelf == false && RoleBox1.transform.GetChild(1).gameObject.activeSelf == false && RoleBox1.transform.GetChild(2).gameObject.activeSelf == false)
            {
                RoleBox1.transform.GetChild(1).gameObject.SetActive(true);
                RoleBox1.transform.GetChild(3).gameObject.GetComponent<Text>().text = FashiRoleID.text;
            }
            else if (RoleBox2.transform.GetChild(0).gameObject.activeSelf == false && RoleBox2.transform.GetChild(1).gameObject.activeSelf == false && RoleBox2.transform.GetChild(2).gameObject.activeSelf == false)
            {
                RoleBox2.transform.GetChild(1).gameObject.SetActive(true);
                RoleBox2.transform.GetChild(3).gameObject.GetComponent<Text>().text = FashiRoleID.text;
            }
            else if (RoleBox3.transform.GetChild(0).gameObject.activeSelf == false && RoleBox3.transform.GetChild(1).gameObject.activeSelf == false && RoleBox3.transform.GetChild(2).gameObject.activeSelf == false)
            {
                RoleBox3.transform.GetChild(1).gameObject.SetActive(true);
                RoleBox3.transform.GetChild(3).gameObject.GetComponent<Text>().text = FashiRoleID.text;
            }
            else
            {
                return;
            }
        }
        FashiRoleID.text = "";
    }
    /// <summary>
    /// 战士角色选择方法
    /// </summary>
    void KnightSelectRole()
    {
        if (KnightRoleID.text != "")
        {
            PlayerOption.SetActive(false);
            PlzyerAffirm.SetActive(true);
            if (RoleBox1.transform.GetChild(0).gameObject.activeSelf == false && RoleBox1.transform.GetChild(1).gameObject.activeSelf == false && RoleBox1.transform.GetChild(2).gameObject.activeSelf == false)
            {
                RoleBox1.transform.GetChild(2).gameObject.SetActive(true);
                RoleBox1.transform.GetChild(3).gameObject.GetComponent<Text>().text = KnightRoleID.text;
            }
            else if (RoleBox2.transform.GetChild(0).gameObject.activeSelf == false && RoleBox2.transform.GetChild(1).gameObject.activeSelf == false && RoleBox2.transform.GetChild(2).gameObject.activeSelf == false)
            {
                RoleBox2.transform.GetChild(2).gameObject.SetActive(true);
                RoleBox2.transform.GetChild(3).gameObject.GetComponent<Text>().text = KnightRoleID.text;
            }
            else if (RoleBox3.transform.GetChild(0).gameObject.activeSelf == false && RoleBox3.transform.GetChild(1).gameObject.activeSelf == false && RoleBox3.transform.GetChild(2).gameObject.activeSelf == false)
            {
                RoleBox3.transform.GetChild(2).gameObject.SetActive(true);
                RoleBox3.transform.GetChild(3).gameObject.GetComponent<Text>().text = KnightRoleID.text;
            }
            else
            {
                return;
            }
        }
        KnightRoleID.text = "";
    }
    /// <summary>
    /// 返回角色框
    /// </summary>
    public void ReturnPlzyerAffirm()
    {
        IsDOTween = false;
        PlayerOption.SetActive(false);
        PlzyerAffirm.SetActive(true);
    }
    /// <summary>
    /// 创建角色界面
    /// </summary>
    public void CreateCharacter()
    {
        IsDOTween = true;
        PlayerOption.SetActive(true);
        PlzyerAffirm.SetActive(false);
    }
}
