using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private int pScore = -2;
    public int pHighScore = 0;
    public Text PScoreText;
    public Text HighScoreText;
    public ModifiedPlayFabManager PlayFabManager;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);

    }

    // Update is called once per frame
    void Update()
    {
        setHighScore();
        PlayerPrefs.SetInt("LatestScore", pScore);
    }

    public void increaseScore(){
        pScore++;
        if (pScore >= 0){
        PScoreText.text = "Score: " + pScore;
        }
    }

    public void setHighScore(){
        if (pScore > PlayerPrefs.GetInt("HighScore")){
        PlayerPrefs.SetInt("HighScore", pScore);
        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log(PlayFabManager);
        PlayFabManager.ModSendLeaderboard(pScore);
        }
    }

    public int GetScore()
    {
        return pScore;
    }
}
