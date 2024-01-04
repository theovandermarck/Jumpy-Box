using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    private bool RedBought;
    private bool GreenBought;
    private bool BlueBought;
    public GameObject playerObj;
    private SpriteRenderer sprite;
    private UnityEngine.UI.Image image;
    void Start()
    {
        string[] boughtColors = sta(PlayerPrefs.GetString("BoughtColors", "1,1,1|0,1,0"));
        UnityEngine.Debug.Log(string.Join("|",boughtColors));
        //RedBought = 
        int[] colorArr = { 0, 0, 1 };
        PlayerPrefs.SetString("CurrentColor",string.Join(",", colorArr));
        image = playerObj.GetComponent<UnityEngine.UI.Image>();
        RenderPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string[] sta(string s)
    {
        string[] a = s.Split('|');
        return a;
    }

    void RenderPlayer()
    {
        int[] colorArr2 = Array.ConvertAll(PlayerPrefs.GetString("CurrentColor", "1,1,1").Split(','), int.Parse);
        UnityEngine.Debug.Log(colorArr2[0]);
        //sprite.color = new Color(colorArr2[0], colorArr2[1], colorArr2[2]);
        image.color = new Color(colorArr2[0], colorArr2[1], colorArr2[2]);
    }

    void HoverIcon()
    {

    }
    void UnhoverIcon()
    {

    }

    public bool buyColor(string String) 
    {
        return true;
    }

}
