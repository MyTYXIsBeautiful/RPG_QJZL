using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region 单例
    private static Player _instance;
    public static Player Instance
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
  
}
