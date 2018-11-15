using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class ChangeAppearance : MonoBehaviour {
    Scene sceneM;
    public int gender;
    public SpriteRenderer part;
    public Sprite[] options;
    public int index;
    public SpriteRenderer skin;
    public Color[] colors;
    public Image skinDisplay;
    public int whatColor;
    public InputField username;
    private DatabaseReference reference;


    private void Start()
    {
        sceneM = SceneManager.GetActiveScene();
        if(sceneM.name == "CreateGirlCharacter")
        {
            gender = 0;
        }else if(sceneM.name == "CreateBoyCharacter")
        {
            gender = 1;
        }
        // ใช้สำหรับอ้างอิง Firebase Project
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveller-c316a.firebaseio.com/"); ของตัวที่ใช้ร่วมกัน
         FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
        // สำหรับใช้ในการอ้างอิง Firebase
         reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void Update () {
        for (int i = 0; i < options.Length; i++)
        {
            if (i == index)
            {
                part.sprite = options[i];
            }
        }

        skinDisplay.color = skin.color;

        for (int i = 0; i < colors.Length; i++)
        {
            if (i == whatColor)
            {
                skin.color = colors[i];
            }
        }
    }
    
    public void Swap()
    {
        if(index < options.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }
    }

    public void changeClothing1()
    {
        if (index < options.Length - 1)
        {
            index =1;
        }
        else
        {
            index = 0;
        }
    }

    public void changeClothing2()
    {
        if (index < options.Length - 1)
        {
            index = 2;
        }
        else
        {
            index = 0;
        }
    }


    public void ChangeSkinColor(int skinId)
    {
        whatColor = skinId;
    }

    public void CreateCharacter()
    {
        SceneManager.LoadScene("Main_1");
        var refPush = reference.Child("User/userId").Push();
        //refPush.Child("Username").SetValueAsync(""+username.text);
        refPush.Child("Skincolor").SetValueAsync(whatColor);
        refPush.Child("Gender").SetValueAsync(gender);
    
        //  refPush.Child("ClothId").SetValueAsync(index);


    }

}
