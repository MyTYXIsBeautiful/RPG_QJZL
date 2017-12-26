using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZBTXScript : MonoBehaviour {

    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public Sprite[] ZBTX;
    float timer = 0;
    int index = 0;
    void Update () {
        timer += Time.deltaTime;
        if (timer >= 0.09f)
        {
            timer = 0;
            image.sprite = ZBTX[index];
        }

        if (index < ZBTX.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }

    }
}
