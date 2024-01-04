using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMessage : MonoBehaviour
{
    public TMPro.TextMeshProUGUI messageDisplay;
    public void DisplayMessage(string message){
        messageDisplay.text=message;
        StartCoroutine(displayDelay());
    }

    IEnumerator displayDelay()
    {
        yield return new WaitForSeconds(5);
        messageDisplay.text="";
    }
}
