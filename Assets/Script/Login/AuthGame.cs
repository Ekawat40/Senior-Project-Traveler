using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class AuthGame : MonoBehaviour
{
    private FirebaseAuth auth;
    public InputField email_input, password_input;
    public Button SignupButton, SigninButton;
    public Text ErrorText;




    // Use this for initialization
    public void Start()
    {
        auth = FirebaseAuth.DefaultInstance;

        SignupButton.onClick.AddListener(() => Signup(email_input.text, password_input.text));
        SigninButton.onClick.AddListener(() => LoginAction(email_input.text, password_input.text));
    }
    public void Signup(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            //Error handling
            return;
        }

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {


            FirebaseUser newUser = task.Result; // Firebase user has been created.
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

        });
    }



    void ClearErrorMessage()
    {
        ErrorText.text = "";
    }
    public void LoginAction(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
           

            FirebaseUser user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);
           // SessionRoot sessionRoot = new SessionRoot();
           // sessionRoot.SessionLoad();
            //PlayerPrefs.SetString("LoginUser", user != null ? user.Email : "Unknown");
            StartCoroutine(LoadNewScene());

        });
    }



    IEnumerator LoadNewScene()
    {

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync("loadingScene");
        while (!async.isDone)
        {
            yield return null;
        }
    }
}