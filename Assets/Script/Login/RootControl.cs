using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RootControl : MonoBehaviour {

    public Button SigninButton,SeesionBtn;
    Scene sceneM;
    //
    public InputField email_input;
    public String RootName;
    public Text showEmail;
    String saveEmail;

 
    // Use this for initialization
    void Start () {
     
        if (sceneM.name == "Login")
        {
            SigninButton.onClick.AddListener(() => LoginAction());
        }else if (sceneM.name == "LogoStart")
        {
            SigninButton.onClick.AddListener(() => SessionLoad());

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void LoginAction()
    {
        Save();
    }

    public void splitWord()
    {
        string[] separatingChars = { "@" };

        string text1 = email_input.text;
        //string text1 = "aekwatt@gmail.com";
        System.Console.WriteLine("Original text: '{0}'", text1);

        string[] words = text1.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
        System.Console.WriteLine("{0} substrings in text:", words.Length);

        Debug.Log(words[0]);

        RootName = words[0];
        //tvRoot.text = RootName;


    }

    public void Save()
    {
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
        showEmail.text = RootName;
        Debug.Log(RootName);
    }

    public void setName()
    {
        //healthValue = PlayerPrefs.GetInt("HealthKey", 0);
        //PlayerPrefs.SetInt("HealthKey", 0);
        if (PlayerPrefs.HasKey("HealthKEy"))
        {
            //do something
        }
        RootName = PlayerPrefs.GetString("RootKey", "");
    }

    public void SessionLoad()
    {
        setName();
        if(RootName != "null")
        {
            SceneManager.LoadScene("mockupmaincharacter");
        }else if(RootName == "null")
        {
            SceneManager.LoadScene("Login");
        }
    }

}
