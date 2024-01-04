using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetInputValue : MonoBehaviour
{
    public TMP_InputField inputField;
    void Start(){
        ChangeInputField();
    }
    public void ChangeInputField(){
        inputField.text=PlayerPrefs.GetString("Username");
    }
}
