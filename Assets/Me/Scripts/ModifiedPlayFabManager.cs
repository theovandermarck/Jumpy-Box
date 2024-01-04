using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class ModifiedPlayFabManager : MonoBehaviour
{
    // public TMPro.TextMeshProUGUI[] rNames;
    // public TMPro.TextMeshProUGUI[] rScores;
    // public TMPro.TextMeshProUGUI currentName;
    // Start is called before the first frame update
    // void Start()
    // {
    //     Login();
    //     currentName.text = "Current Name: " + PlayerPrefs.GetString("Username");
    // }

    // // Update is called once per frame
    // void Login()
    // {
    //     var request = new LoginWithCustomIDRequest {
    //         CustomId=SystemInfo.deviceUniqueIdentifier,
    //         CreateAccount = true,
    //         InfoRequestParameters = new GetPlayerCombinedInfoRequestParams {
    //             GetPlayerProfile = true
    //         }
    //     };
    //     PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    // }
    // void OnLoginSuccess(LoginResult result) {
    //     Debug.Log("Successful login/account create!");
    //     GetLeaderboard();
    //     name = result.InfoResultPayload.PlayerProfile.DisplayName;
            
    //     Debug.Log(name);
    // }

    void ModOnError(PlayFabError error) {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }

    public void ModSendLeaderboard(int score){
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate{
                    StatisticName = "High Score",
                    Value = score
                }
            }
        };
        Debug.Log("smth happened idk what");
        PlayFabClientAPI.UpdatePlayerStatistics(request, ModOnLeaderboardUpdate, ModOnError);
    }

    void ModOnLeaderboardUpdate(UpdatePlayerStatisticsResult result) {
        Debug.Log("Successful leaderboard!");
    }
    // PlayFabManager.SendLeaderboard(pScore);
    

    // public void ModGetLeaderboard(){
    //     var request =  new GetLeaderboardRequest {
    //         StatisticName = "High Score",
    //         StartPosition = 0,
    //         MaxResultsCount = 10
    //     };
    //     PlayFabClientAPI.GetLeaderboard(request, ModOnLeaderboardGet, ModOnError);
    // }

    // void ModOnLeaderboardGet(GetLeaderboardResult result) {
    //     for(int i = 0; i < 3; i++)
    //     {
    //         rNames[i].text = result.Leaderboard[i].DisplayName;
    //         rScores[i].text = result.Leaderboard[i].StatValue.ToString();
    //     }
    //     Debug.Log(result.Leaderboard[0].Position);
    //     foreach (var item in result.Leaderboard) {
    //         Debug.Log(string.Format("Place: {0} | ID: {1} | Value: {2}",item.Position, item.PlayFabId, item.StatValue));
    //     }
    // }

//     public void SetName(string userName) {
//         var request = new UpdateUserDataRequest {
//             Data = new Dictionary<string,string> {
//                 {"Name", userName}
//             }
//         };
//         PlayFabClientAPI.UpdateUserData(request,OnDataSend, OnError);
//     }

//     public void GetName(){
//         PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
//     }

//     public void OnDataReceived(GetUserDataResult result){
//         Debug.Log("Received user data!");
//         if (result.Data != null && result.Data.ContainsKey("Name")){
//             Debug.Log(result.Data["Name"].Value);
//         }
//     }

//     void OnDataSend(UpdateUserDataResult result){
//         Debug.Log("Successful Name Upload!");
//     }

//     public void SubmitName(string inputName){
//         var request = new UpdateUserTitleDisplayNameRequest {
//             DisplayName = inputName,
//         };
//         PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate,OnError);
//         PlayerPrefs.SetString("Username", inputName);
//         currentName.text = "Current Name: " + PlayerPrefs.GetString("Username");
//     }

//     void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result){
//         Debug.Log("Updated display name!");
//     }
} 
