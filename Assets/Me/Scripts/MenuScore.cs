using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{   
    public TMPro.TextMeshProUGUI latestScoreText;
    public TMPro.TextMeshProUGUI highScoreText;
    public TMPro.TextMeshProUGUI creditsText;
    public TMPro.TextMeshProUGUI creditsText2;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        latestScoreText.text = "Score: " + PlayerPrefs.GetInt("LatestScore", 0);
        creditsText.text = "Credits: " + PlayerPrefs.GetInt("Credits", 0);
        creditsText2.text = "Credits: " + PlayerPrefs.GetInt("Credits", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
