using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// 人物选择
/// </summary>
public class PlayerChange : MonoBehaviour
{
    #region 单例模式
    private static PlayerChange _instance;

    public static PlayerChange Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion
    private void Awake()
    {
        _instance = this;
    }
    public Button LeftBtn;
    public Button RightBtn;
    public GameObject PlayerInterfaceParent;
    private Vector3 PlayerChangeInterfacesZeroPos;
    public GameObject CIKE_Plane;
    public GameObject FASHI_Plane;
    public GameObject Knight_Plane;



    private void Start()
    {

    }
    int count = 0;
    private void Update()
    {
        if (count == 0)
        {
            LeftBtn.gameObject.SetActive(false);
        }
        else
        {
            LeftBtn.gameObject.SetActive(true);
        }
        if (count == 2)
        {
            RightBtn.gameObject.SetActive(false);
        }
        else
        {
            RightBtn.gameObject.SetActive(true);
        }
    }

    
    public void RightBtnClick()
    {
        if (PlayerSelectScript.Instance.IsDOTween)
        {
            if (count == 0)
            {
                PlayerInterfaceParent.transform.DOLocalMove(new Vector3(-1200, 0, 0), 0.5f);
                count++;
                CIKE_Plane.SetActive(false);
                FASHI_Plane.SetActive(true);
                Knight_Plane.SetActive(false);
                return;
            }
            if (count == 1)
            {
                PlayerInterfaceParent.transform.DOLocalMove(new Vector3(-2400, 0, 0), 0.5f);
                count++;
                CIKE_Plane.SetActive(false);
                FASHI_Plane.SetActive(false);
                Knight_Plane.SetActive(true);
            }
        }
        
    }
    public void LeftBtnClick()
    {
        if (PlayerSelectScript.Instance.IsDOTween)
        {
            if (count == 2)
            {
                PlayerInterfaceParent.transform.DOLocalMove(new Vector3(-1200, 0, 0), 0.5f);
                count--;
                CIKE_Plane.SetActive(false);
                FASHI_Plane.SetActive(true);
                Knight_Plane.SetActive(false);
                return;
            }
            if (count == 1)
            {
                PlayerInterfaceParent.transform.DOLocalMove(new Vector3(0, 0, 0), 0.5f);
                count--;
                CIKE_Plane.SetActive(true);
                FASHI_Plane.SetActive(false);
                Knight_Plane.SetActive(false);
            }
        }         
    }



}
