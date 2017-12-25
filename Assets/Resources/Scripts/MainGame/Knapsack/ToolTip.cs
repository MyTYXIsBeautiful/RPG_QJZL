using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

    private Text toolTipText;
    private Text contentText;
    private CanvasGroup canvasGroup;
    private float targetAlpha = 0;

    public float smoothing = 1;
    private void Start()
    {
        toolTipText = GetComponent<Text>();
        contentText = transform.Find("Content").GetComponent<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        if (canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.01f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }
    }
    /// <summary>
    /// 显示信息提示面板
    /// </summary>
    /// <param name="text"></param>
    public void Show(string text)
    {
        toolTipText.text = text;
        contentText.text = text;
        targetAlpha = 1;
    }
    /// <summary>
    /// 隐藏信息提示面板
    /// </summary>
    public void Hide()
    {
        targetAlpha = 0;
    }
    /// <summary>
    /// 设置局部坐标
    /// </summary>
    /// <param name="position"></param>
    public void SetLocalPotion(Vector3 position)
    {
        transform.localPosition = position;
    }
}
