using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class LoginScript : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject gameEmail;
    public GameObject gamePass;
    public Button loginBtn;
    public Button registerBtn;

    public GameObject popUpPanel;
    public Button popUpBtn;
    public Text popUpText;

    private string userEmail;
    private string userPass;
    private string username;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        loginBtn = GameObject.Find("LoginBtn").GetComponent<Button>();
        loginBtn.onClick.AddListener(validateLogin);

        registerBtn = GameObject.Find("RegisterBtn").GetComponent<Button>();
        registerBtn.onClick.AddListener(validateRegister);

        popUpBtn = GameObject.Find("PopUpBtn").GetComponent<Button>();
        popUpBtn.onClick.AddListener(popUpClosePressed);

        popUpText = GameObject.Find("PopUpText").GetComponent<Text>();

        popUpPanel.SetActive(false);

        if (PlayerPrefs.HasKey("EMAIL"))
        {
            userEmail = PlayerPrefs.GetString("EMAIL");
            userPass = PlayerPrefs.GetString("PASSWORD");
            var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPass };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
        }
    }

    private void validateLogin()
    {
        Debug.Log("Login Button Pressed");

        userEmail = gameEmail.GetComponent<InputField>().text;
        userPass = gamePass.GetComponent<InputField>().text;


        Debug.Log(userEmail + ", " + userPass);

        var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPass };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);

        //SceneManager.LoadScene(1);
    }

    private void validateRegister()
    {
        Debug.Log("Register Button Pressed");

        userEmail = gameEmail.GetComponent<InputField>().text;
        userPass = gamePass.GetComponent<InputField>().text;

        var registerRequest = new RegisterPlayFabUserRequest { Email = userEmail, Password = userPass, Username = userPass };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login Successful");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPass);
        loginPanel.SetActive(false);
        SceneManager.LoadScene(2);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        popUpText.text = error.GenerateErrorReport();
        popUpPanel.SetActive(true);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Register Successful");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPass);
        popUpText.text = "Account successfully created!";
        popUpPanel.SetActive(true);
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        popUpText.text = error.GenerateErrorReport();
        popUpPanel.SetActive(true);
    }

    private void popUpClosePressed()
    {
        Debug.Log("popUpClose pressed");
        popUpPanel.SetActive(false);
    }

    public void GetUserEmail(string emailIn)
    {
        userEmail = emailIn;
    }

    public void GetUserPassword(string passwordIn)
    {
        userPass = passwordIn;
    }

    public void GetUsername(string usernameIn)
    {
        username = usernameIn;
        Debug.Log("GetUsername: " + username);
    }
}
