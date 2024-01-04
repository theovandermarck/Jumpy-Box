using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScript : MonoBehaviour
{
    public GameObject scriptingObj;
    public void buyColor(int cost)
    {
        if (PlayerPrefs.GetInt("Credits", 0)>cost)
        {
            scriptingObj.GetComponent<Shop>().buyColor("Red");
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits", 0) - cost);
        }
    }
}
