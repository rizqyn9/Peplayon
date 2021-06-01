using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using Matchmaker;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(MatchMakerServices))]
public class MatchBtn : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] Button PublicBtn;
    [SerializeField] Button PrivateBtn;
    [SerializeField] Button JoinBtn;
    [SerializeField] Button AutoBtn;
    [SerializeField] InputField JoinField;

    [Header("Game Scene")]
    public string LobbyScene;

    HttpClient client = new HttpClient();

    [Header("Matchmaker")]
    public string baseURL = "http://localhost:3000/matchmaker";


    public void StartPublic()
    {
        Debug.Log($"Start Public");
        Room result = GetComponent<MatchMakerServices>().ReqMatchPublic(baseURL);
        Debug.Log($"Port {result.Port}");
        GlobalVariables.MatchData = result;
        LoadGame(result);
    }

    public void StartPrivate()
    {
        Debug.Log($"Start Private");
        Room result = GetComponent<MatchMakerServices>().ReqMatchPrivate(baseURL);
        GlobalVariables.MatchData = result;
        LoadGame(result);
    }

    public void StartJoin()
    {
        Debug.Log($"{JoinField.text}");
        Debug.Log($"Start Join");
        GetComponent<MatchMakerServices>().ReqMatchJoin(baseURL, JoinField.text);

    }

    public void StartAuto()
    {
        Debug.Log($"Start Auto");
        GetComponent<MatchMakerServices>().ReqMatchPrivate(baseURL);
    }

    public void LoadGame(Room _room)
    {
        SceneManager.LoadSceneAsync(LobbyScene, LoadSceneMode.Single);
    }
}
