using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    public GameObject playerObj;
    // Start is called before the first frame update
    public SpriteRenderer sprite;
    void Start()
    {
        //int[] colorArr = { 0, 0, 1 };
        //string colorStr = string.Join(",", colorArr);
        int[] colorArr2 = Array.ConvertAll(PlayerPrefs.GetString("CurrentColor", "1,1,1").Split(','), int.Parse);
        sprite = GetComponent<SpriteRenderer>();
        UnityEngine.Debug.Log(colorArr2[0]);
        sprite.color = new Color(colorArr2[0], colorArr2[1], colorArr2[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
