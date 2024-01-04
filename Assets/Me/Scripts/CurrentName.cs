using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentName : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentName;
    // Start is called before the first frame update
    void Start()
    {
        ChangeCurrentName(PlayerPrefs.GetString("Username"));
        Debug.Log("current name: "+PlayerPrefs.GetString("Username"));
    }

    public void ChangeCurrentName(string newName){
        PlayerPrefs.SetString("Username", newName);
        currentName.text = "Current Name: " + newName;
    }
}
