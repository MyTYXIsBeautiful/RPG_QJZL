using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// 开始界面的逻辑
/// </summary>
public class LoginUIScript : MonoBehaviour
{

    public GameObject Login_Fail;   //登陆 密码错误界面

    public GameObject RegisterFail;     //注册数据库已存在账号错误界面
    public GameObject RegPassWordFail;  //密码与确认密码不一致错误界面

    public Button Register_LoginBtn;    //注册成功并登陆按钮

    public Button Login_Btn;            //登陆界面登陆按钮

    public InputField Login_UserName;   //登陆界面账号
    public InputField Login_UserPassWord;   //登陆界面密码

    public InputField Register_UserName;    //注册界面账号
    public InputField Register_UserPassWord;    //注册界面密码
    public InputField Register_UserConfirmPass; //注册界面确认密码

    private void Start()
    {
        //登陆登陆按钮
        Login_Btn.onClick.AddListener(() =>
        {
            
            //连接数据库
            //查询数据库中是否存在输入的账号密码
           
            //如果没有 显示 Login_Fail页面

            if(Login_UserName.text==""|| Login_UserPassWord.text == "")
            {
                Login_Fail.SetActive(true);
            }else
            {
                //如果有 那么跳转页面       
                SceneManager.LoadScene(ConstScript.PlayerSelect);
            }


        });
        //注册界面的注册并登陆按钮
        Register_LoginBtn.onClick.AddListener(()=>
        {
            //首先验证密码与确认密码是否一致,如果不一致显示RegPassWordFail界面
            //连接数据库
            //查询数据库中是否有输入的账号
            //如果有提示玩家该用户已存在,RegisterFail界面显示
            //如果没有那么向数据库中插入玩家输入的账号和密码并登陆
            if(Register_UserName.text==""|| Register_UserPassWord.text=="" || Register_UserConfirmPass.text == "")
            {
                    RegPassWordFail.SetActive(true);
            }else
            {
                SceneManager.LoadScene(ConstScript.PlayerSelect);
            }
        });
    }
}
