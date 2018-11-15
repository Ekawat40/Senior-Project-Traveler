using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;
using System;

public class ChangeAppearances : MonoBehaviour {
    Scene sceneM;
    public Color[] colors;
    public Sprite[] cOptions;
    public Sprite[] hOptions;
    public int whatColor = 0;
    public int clothId = 0;
    public int hairId = 0;
    public int gender;
    public SpriteRenderer skin;
    public SpriteRenderer cloth;
    public SpriteRenderer hair;
    private DatabaseReference reference;
    public Button SigninButton;

    //
    public InputField email_input;
    public String RootName;
    public Text showEmail;
    String saveEmail;



    // Use this for initialization
    void Start () {
        sceneM = SceneManager.GetActiveScene();
        if (sceneM.name == "CreateGirlCharacter")
        {
            Load();
            gender = 0;
        }
        else if (sceneM.name == "CreateBoyCharacter")
        {
            Load();
            gender = 1;
        }
        else if(sceneM.name == "Login")
        {
            SigninButton.onClick.AddListener(() => LoginAction());
        }
        // ใช้สำหรับอ้างอิง Firebase Project
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveller-c316a.firebaseio.com/"); ของตัวที่ใช้ร่วมกัน
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
        // สำหรับใช้ในการอ้างอิง Firebase
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        reference.Child("User/" + RootName).Child("State").SetValueAsync(0);
    }

    public void LoginAction()
    {
        Save();
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < colors.Length; i++)
        {
            if (i == whatColor)
            {
                skin.color = colors[i];
            }
        }
        for (int i = 0; i < cOptions.Length; i++)
        {
            if (i == clothId)
            {
                cloth.sprite = cOptions[i];
            }
        }
        for (int i = 0; i < hOptions.Length; i++)
        {
            if (i == hairId)
            {
                hair.sprite = hOptions[i];
            }
        }
    }

    public void CreateCharacter()
    {
        //var refPush = reference.Child("User"+ RootName).Push();
        //refPush.Child("Username").SetValueAsync(""+username.text);
        reference.Child("User/" + RootName).Child("Skincolor").SetValueAsync(whatColor);
        reference.Child("User/" + RootName).Child("Skincolor").SetValueAsync(whatColor);
        reference.Child("User/" + RootName).Child("Gender").SetValueAsync(gender);
        reference.Child("User/" + RootName).Child("ClothId").SetValueAsync(clothId);
        reference.Child("User/" + RootName).Child("HairId").SetValueAsync(hairId);
        reference.Child("User/" + RootName).Child("StepCount").SetValueAsync(0);
        reference.Child("User/" + RootName).Child("Money").SetValueAsync(0);
        reference.Child("User/" + RootName).Child("State").SetValueAsync(1);


        SceneManager.LoadScene("mockupmaincharacter");
    }

    public void ChangeSkinColor(int skinId)
    {
        whatColor = skinId;
    }
    public void ChangeCloth(int cId)
    {
        clothId = cId;
    }
    public void ChangeHair(int hId)
    {
        hairId = hId;
    }

    public void btn()
    {
        Save();

        SceneManager.LoadScene("CreateGirlCharacter");

    }

    public void btnGender()
    {
        Save();
        //SceneManager.LoadScene("ChooseGender");
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

    public void btnCreate()
    {
        SceneManager.LoadScene("CreateGirlCharacter");
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

}
