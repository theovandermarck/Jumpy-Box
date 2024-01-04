using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnabler : MonoBehaviour
{
    public GameObject jb;
    public GameObject cb;
    int buttonVisibility;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("mobileButtons", 0)==1){
            jb.SetActive(true);
            cb.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
