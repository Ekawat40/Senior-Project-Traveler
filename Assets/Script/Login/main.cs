using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;


public class main : MonoBehaviour
{
    private FirebaseAuth auth;
    public InputField email_input, password_input;
    public Button SignupButton, SigninButton;
    public Text ErrorText,showEmail;
    // Use this for initialization


    //public Text textValue;

    //int healthValue = 0;

    String saveEmail;

    //

    public void Save()
    {
        saveEmail = email_input.text;
        //PlayerPrefs.SetInt("HealthKey", healthValue);
        PlayerPrefs.SetString("EmailKey", saveEmail);
    }

    public void Load()
    {
        //healthValue = PlayerPrefs.GetInt("HealthKey", 0);
        //PlayerPrefs.SetInt("HealthKey", 0);
        if (PlayerPrefs.HasKey("HealthKEy"))
        {
            //do something
        }
        //email_input.text = healthValue.ToString();


        saveEmail = PlayerPrefs.GetString("EmailKey", "");
        if (PlayerPrefs.HasKey("HealthKEy"))
        {
            //do something
        }
        //email_input.text = healthValue.ToString();

        showEmail.text = saveEmail;

    }



    public void Start()

    {
        Load();
        auth = FirebaseAuth.DefaultInstance;
        SignupButton.onClick.AddListener(() => Signup(email_input.text, password_input.text));
        SigninButton.onClick.AddListener(() => LoginAction(email_input.text, password_input.text));

    }


    public void Signup(string email, string password) //สมัครสมาชิก
    {
      
  
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            //Error handling
            return;
        }

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                    UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
                return;
            }

            FirebaseUser newUser = task.Result; // Firebase user has been created.
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            UpdateErrorMessage("Signup Success");
        });

        

    }

    private void UpdateErrorMessage(string message)
    {
        ErrorText.text = message;
        Invoke("ClearErrorMessage", 3);
    }

    void ClearErrorMessage()
    {
        ErrorText.text = "";
    }
    public void LoginAction(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                    UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
                return;
            }

            FirebaseUser user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);

            PlayerPrefs.SetString("LoginUser", user != null ? user.Email : "Unknown");
            //SceneManager.LoadScene("LogoStart");
            StartCoroutine(LoadNewScene());
        });

        Save();
    }

    public void LogOutAction(string email, string password)
    {

    }

    IEnumerator LoadNewScene()
    {

        yield return new WaitForSeconds(3);

        AsyncOperation async = SceneManager.LoadSceneAsync("LogoStart");
        while (!async.isDone)
        {
            yield return null;
        }


    }


}