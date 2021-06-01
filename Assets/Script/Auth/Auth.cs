using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;


public class Auth : MonoBehaviour
{
    HttpClient client = new HttpClient();

    [Header("Net Server")]
    public string baseURL = "http://localhost:3000/api";

    [Header("Login")]
    public Canvas CanvasLogin;
    [SerializeField] InputField UserNameLogin;
    [SerializeField] InputField PassLogin;
    [SerializeField] Button BtnLogin;

    [Header("SignUp")]
    public Canvas CanvasSignUp;
    [SerializeField] InputField NameSignUp;
    [SerializeField] InputField UserNameSignUp;
    [SerializeField] InputField PassSignUp;
    [SerializeField] Button BtnSignUp;

    [Header("ID")]
    public string ID;

    [Header("Scene Management")]
    [SerializeField] public string NextScene;

    bool isLoading = false;

    private void Start()
    {
        if (PlayerPrefs.HasKey("ID"))
        {
            ID = PlayerPrefs.GetString("ID");
            Debug.Log(ID);
            Debug.Log(PlayerPrefs.GetString("UserName"));
            Debug.Log(PlayerPrefs.GetString("Name"));
            CanvasSignUp.enabled = true;

            /*
             * Auto Login with session ticket
             */

            HttpResponseMessage response = client.GetAsync(baseURL + "/getdata" + $"/{ID}").GetAwaiter().GetResult();
            string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Debug.Log(responseStr);
            Response responseJSON = JsonConvert.DeserializeObject<Response>(responseStr);

            if (response.IsSuccessStatusCode)
            {
                //Test
                SetPlayerData(responseJSON);
                SaveTicketID(responseJSON._id);
                Debug.Log("Success");
                SceneSuccess();
            }
            else
            {
                Debug.Log("Err");
            }
        } else
        {
            CanvasSignUp.enabled = true;
        }

    }

    private void Update()
    {
        if (isLoading)
        {
            Debug.Log("Loading");
        }
    }

    #region UI Handling

    public void toSignUp ()
    {
        CanvasLogin.enabled = false;
        CanvasSignUp.enabled = true;
    }

    public void toLogin()
    {
        CanvasSignUp.enabled = false;
        CanvasLogin.enabled = true;
    }

    #endregion


    public void SignUp()
    {
        Debug.Log("Sign Up");
        isLoading = true;
        POST SignUp_Data = new POST(NameSignUp.text, UserNameSignUp.text, PassSignUp.text);
        var FormSignUp = new StringContent(SignUp_Data.ToJSON(), Encoding.UTF8, "application/json");
        HttpResponseMessage response = client.PostAsync(baseURL + "/signup", FormSignUp).GetAwaiter().GetResult();
        string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        Debug.Log(responseStr);

        Response responseJSON = JsonConvert.DeserializeObject<Response>(responseStr);
        Debug.Log(responseJSON._id);

        //Checking Success
        if (response.IsSuccessStatusCode)
        {
            isLoading = false;
            Debug.Log("Success");
            toLogin();
        }
        else
        {
            Debug.Log("Err");
        }
    }

    public void Login()
    {
        Debug.Log("Login");
        POST SignIn_Data = new POST(null, UserNameLogin.text, PassLogin.text);
        Debug.Log(UserNameLogin.text);
        Debug.Log(PassLogin.text);
        var FormSignIn = new StringContent(SignIn_Data.ToJSON(), Encoding.UTF8, "application/json");
        HttpResponseMessage response = client.PostAsync(baseURL + "/signin", FormSignIn).GetAwaiter().GetResult();
        string responseStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        Debug.Log(responseStr);
        Response responseJSON = JsonConvert.DeserializeObject<Response>(responseStr);

        //Test
        //LocalPlayerData contoh = new LocalPlayerData("idasd", "Rizqy", 12);
        //Checking Success
        if (response.IsSuccessStatusCode)
        {
            SetPlayerData(responseJSON);
            SaveTicketID(responseJSON._id);
            Debug.Log("Success");
            SceneSuccess();
        }
        else
        {
            Debug.Log("Err");
        }
    }

    public void SaveTicketID(string _id)
    {
        Debug.Log("Auth --> Save ID");
        ID = _id;
        PlayerPrefs.SetString("ID", _id);
    }

    public void SetPlayerData (Response _data)
    {
        Debug.Log("Auth --> Set Player data");
        Debug.Log($"{_data._id}");
        PlayerPrefs.SetString("Name", _data.Name);
        PlayerPrefs.SetString("UserName", _data.UserName);
        PlayerPrefs.SetInt("Level", _data.Level);
        PlayerPrefs.SetString("PlayerID", _data.PlayerID);

    }

    public void SceneSuccess()
    {
        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
    }
}


public class Response
{
    public string _id;
    public string Name;
    public string UserName;
    public string PlayerID;
    public int Level;
    public object Character;
    
}



