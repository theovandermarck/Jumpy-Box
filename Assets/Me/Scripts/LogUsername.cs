using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogUsername : MonoBehaviour
{
    public string user;

    public void setNewUsername(string e){
        PlayerPrefs.SetString("username",e);
        user=e;
    }
}
