using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 人物选择界面的人物旋转
/// </summary>
public class PlayerRotate : MonoBehaviour {

    public GameObject Player;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SpinWithMouseFunc();
    }
    private bool isRotating = false;//是否移动，标志位
    private void SpinWithMouseFunc()
    {
        if (Input.GetMouseButton(0))//鼠标左键一直按下isRotating设为true
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(0))//鼠标左键抬起isRotating设为false
        {
            isRotating = false;
        }
        if (isRotating)
        {
            Player.transform.Rotate(-Vector3.up, Time.deltaTime * 150 * Input.GetAxis("Mouse X"), Space.Self);
        }
    }
}
