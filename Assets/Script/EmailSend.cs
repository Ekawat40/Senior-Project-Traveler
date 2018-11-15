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


public class EmailSend : MonoBehaviour {
    private DatabaseReference reference;
    public InputField email_input;
    String RootName;
    public Text tvRoot, showEmail;
    String saveEmail;
    Scene sceneM;



    // Use this for initialization
    void Start () {
        sceneM = SceneManager.GetActiveScene();
        if (sceneM.name == "NextSc")
        {
            Load();
        }
        else if (sceneM.name == "testSc")
        {
            
        }
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
        // สำหรับใช้ในการอ้างอิง Firebase
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
	
	// Update is called once per frame
	void Update () {

    }



    public void btn()
    {
        Save();

        SceneManager.LoadScene("NextSc");
        /*reference.Child("User/" + words[0]).Child("Skincolor").SetValueAsync("null");
        reference.Child("User/" + words[0]).Child("Gender").SetValueAsync("null");
        reference.Child("User/" + words[0]).Child("ClothId").SetValueAsync("null");
        reference.Child("User/" + words[0]).Child("HairId").SetValueAsync("null");*/
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
        //saveEmail = email_input.text;
        //PlayerPrefs.SetInt("HealthKey", healthValue);
        PlayerPrefs.SetString("RootKey", RootName);


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


        RootName = PlayerPrefs.GetString("RootKey", "");
        if (PlayerPrefs.HasKey("HealthKEy"))
        {
            //do something
        }
        //email_input.text = healthValue.ToString();
        showEmail.text = RootName;
    }



}
