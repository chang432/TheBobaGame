using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{

	public GameObject username;
	public GameObject password;
	public GameObject login;

	public Button loginBtn;

	private string Username;
	private string Password;

    // Start is called before the first frame update
    void Start()
    {
        print("Start");
    }

    // Update is called once per frame
    void Update()
    {
    	Username = username.GetComponent<InputField> ().text;
    	Password = password.GetComponent<InputField> ().text;

    	loginBtn = login.GetComponent<Button>();
    	loginBtn.onClick.AddListener(validateLogin);
    }

    void validateLogin() {
    	print("WHATS UP BOIII");
    	SceneManager.LoadScene(1);
    }

}
