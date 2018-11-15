using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SessionRoot : MonoBehaviour {
    Scene sceneM;
    public InputField email_input;
    public String RootName;
    String saveEmail;
    public Button SigninButton;
    // Use this for initialization
    void Start () {

        if (sceneM.name == "mockupmaincharacter")
        {
            Load();

        }else if (sceneM.name == "LogoStart")
        {
           // getRoot();
           // SSTools.ShowMessage("Click LogoStart", SSTools.Position.bottom, SSTools.Time.twoSecond);
           //SeesionBtn.onClick.AddListener(() => SessionLoad());

        }else if (sceneM.name == "Login")
        {
            SigninButton.onClick.AddListener(() => LoginAction());
        }

    }

    public void LoginAction()
    {
        Save();
    }

    public void Save()
    {
        /*splitWord();
        if(rootLastName == "gmail.com")
        {
            PlayerPrefs.SetString("RootKey", RootName);
        }
        else
        {
            SSTools.ShowMessage("EmailError", SSTools.Position.bottom, SSTools.Time.twoSecond);
        }*/
        //PlayerPrefs.SetString("RootKey", RootName);

        splitWord();

        PlayerPrefs.SetString("RootKey", RootName);

    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("RootKEy"))
        {
            //do something
        }
        //email_input.text = healthValue.ToString();
        RootName = PlayerPrefs.GetString("RootKey", "");
        if (PlayerPrefs.HasKey("RootKEy"))
        {
            //do something
        }
        //showEmail.text = RootName;
        Debug.Log(RootName);
    }

    public void splitWord()
    {
        string[] separatingChars = { "@" };

        string text1 = email_input.text;
        //string text1 = "aekwatt@gmail.com";
        //System.Console.WriteLine("Original text: '{0}'", text1);

        string[] words = text1.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
        //System.Console.WriteLine("{0} substrings in text:", words.Length);

        Debug.Log(words[0]);

        RootName = words[0];

        //tvRoot.text = RootName;


    }

    public void btnCreate()
    {
        SceneManager.LoadScene("CreateGirlCharacter");
    }


    public void getRoot()
    {
       //healthValue = PlayerPrefs.GetInt("HealthKey", 0);
        //PlayerPrefs.SetInt("HealthKey", 0);
        if (PlayerPrefs.HasKey("HealthKEy"))
        {
            //do something
        }
        RootName = PlayerPrefs.GetString("RootKey", "");


    }

    public void LogOut()
    {
        SSTools.ShowMessage("Logout", SSTools.Position.bottom, SSTools.Time.twoSecond);
        RootName = "null";
        PlayerPrefs.SetString("RootKey", RootName);
        //Save();
        //PlayerPrefs.DeleteKey("RootKey");
        SceneManager.LoadScene("LogoStart");
    }

    public void SessionLoad()
    {
        getRoot();
        /* if (RootName != null)
         {
             Debug.Log(RootName);
             SceneManager.LoadScene("mockupmaincharacter");
         }
         else if (RootName == null)
         {
             SceneManager.LoadScene("Login");
         }*/

        /*if(rootLastName == RootName)
        {
            Debug.Log("Error Email");
        }*/



        if (RootName == "null")
        {
            SceneManager.LoadScene("Login");
        }
        else if (RootName != "null")
        {
            SceneManager.LoadScene("mockupmaincharacter");
        }

        SSTools.ShowMessage(RootName, SSTools.Position.bottom, SSTools.Time.twoSecond);
    }
}
