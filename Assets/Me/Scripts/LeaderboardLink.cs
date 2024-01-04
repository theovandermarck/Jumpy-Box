using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardLink : MonoBehaviour
{
    public void OpenLeaderboard()
    {
        Application.OpenURL("https://jumpybox.glitch.me");
    }
}
