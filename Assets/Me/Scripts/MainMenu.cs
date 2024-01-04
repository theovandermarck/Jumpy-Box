using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool MainScript = false;
    public TMPro.TextMeshProUGUI buttonsButton;
    public int mobileButtons = 0;
    public GameObject DefaultSceneParent;
    public GameObject ShopSceneParent;

    public void Start(){
        if (MainScript)
        {
            mobileButtons = PlayerPrefs.GetInt("mobileButtons", 0);
            if (mobileButtons == 1)
            {
                buttonsButton.text = "BUTTONS: ON";
            }
            else
            {
                buttonsButton.text = "BUTTONS: OFF";
            }
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ToggleButtons()
    {
        if (mobileButtons==0){
            mobileButtons=1;
            PlayerPrefs.SetInt("mobileButtons",1);
            buttonsButton.text = "BUTTONS: ON";
        }else if (mobileButtons==1){
            mobileButtons=0;
            PlayerPrefs.SetInt("mobileButtons",0);
            buttonsButton.text="BUTTONS: OFF";
        }
    }
    public void loadShop(bool tf)
    {
        DefaultSceneParent.SetActive(!tf);
        ShopSceneParent.SetActive(tf);
    }
}
