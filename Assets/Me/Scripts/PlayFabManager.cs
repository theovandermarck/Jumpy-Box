using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI[] rNames;
    public TMPro.TextMeshProUGUI[] rScores;
    public TMPro.TextMeshProUGUI currentName;
    public MenuMessage menuMessage;
    public CurrentName currentNameScript;
    public string possibleName;
    // Start is called before the first frame update
    void Start()
    {
        GenerateNewGUID();
        currentName.text = "Current Name: " + PlayerPrefs.GetString("Username");
    }

    void GenerateNewGUID(){
        if (!PlayerPrefs.HasKey("UniqueIdentifier"))
            PlayerPrefs.SetString("UniqueIdentifier", System.Guid.NewGuid().ToString());
        Login();
        Debug.Log("GUID: "+PlayerPrefs.GetString("UniqueIdentifier"));
    }

    // Update is called once per frame
    void Login()
    {
        var request = new LoginWithCustomIDRequest {
            CustomId=PlayerPrefs.GetString("UniqueIdentifier"),
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result) {
        Debug.Log("Successful login/account create!");
        GetLeaderboard();
        name = result.InfoResultPayload.PlayerProfile.DisplayName;
            
        Debug.Log(name);
    }

    void OnError(PlayFabError error) {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score){
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate{
                    StatisticName = "High Score",
                    Value = score
                }
            }
        };
        Debug.Log("smth happened idk what");
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) {
        Debug.Log("Successful leaderboard!");
    }
    // PlayFabManager.SendLeaderboard(pScore);
    

    public void GetLeaderboard(){
        var request =  new GetLeaderboardRequest {
            StatisticName = "High Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result) {
        for(int i = 0; i < 3; i++)
        {
            rNames[i].text = result.Leaderboard[i].DisplayName;
            rScores[i].text = result.Leaderboard[i].StatValue.ToString();
        }
        Debug.Log("statvalue"+result.Leaderboard[0].StatValue);
        foreach (var item in result.Leaderboard) {
            Debug.Log(string.Format("Place: {0} | ID: {1} | Value: {2}",item.Position, item.PlayFabId, item.StatValue));
        }
    }

    public void SetName(string userName) {
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string,string> {
                {"Name", userName}
            }
        };
        PlayFabClientAPI.UpdateUserData(request,OnDataSend, OnError);
    }

    public void GetName(){
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    public void OnDataReceived(GetUserDataResult result){
        Debug.Log("Received user data!");
        if (result.Data != null && result.Data.ContainsKey("Name")){
            Debug.Log(result.Data["Name"].Value);
        }
    }

    void OnDataSend(UpdateUserDataResult result){
        Debug.Log("Successful Name Upload!");
    }

    public void SubmitName(string inputName){
        var request = new UpdateUserTitleDisplayNameRequest {
            DisplayName = inputName,
        };
        possibleName = inputName;
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate,OnNameError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result){
        Debug.Log("Updated display name!");
        PlayerPrefs.SetString("Username", possibleName);
        currentNameScript.ChangeCurrentName(PlayerPrefs.GetString("Username"));
        Debug.Log(PlayerPrefs.GetString("Username"));
    }

    void OnNameError(PlayFabError error) {
        menuMessage.DisplayMessage(error.GenerateErrorReport());
    }
} 
