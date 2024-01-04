using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay=1f;
    public void EndGame(){
        Debug.Log("DEAD");
        Invoke("Restart", restartDelay);
        FindObjectOfType<MovementDisabler>().DisableMovement();
        FindObjectOfType<PlaySound>().PlayDeath();
        PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits", 0)+FindObjectOfType<score>().GetScore());
    }

    void Restart (){
        SceneManager.LoadScene("Menu");
    }
}
