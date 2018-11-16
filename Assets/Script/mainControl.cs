using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;
using System;


public class mainControl : RootControl
{
    public Color[] colors;
    public Sprite[] boycOptions;
    public Sprite[] girlcOptions;
    public Sprite[] boyhOptions;
    public Sprite[] girlhOptions;
    public Sprite[] bOptions;
    public SpriteRenderer skin;
    public SpriteRenderer cloth;
    public SpriteRenderer hair;
    public SpriteRenderer body;
    int hairId;
    int skinId;
    int clothId;
    int gender;
    string j;
    //string uId;
    // Use this for initialization
    DatabaseReference reference;
    void Start()
    {
        setName();
        //FirebaseApp.DefaultInstance.SetEditorAuthUserId(uId); 
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveller-c316a.firebaseio.com/");
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance
    //.GetReference("User/-LQ7HR3MZlLsh_dWueW1/Skincolor") //แทน key ด้วย uId 
    .GetReference("User/" + RootName + "/Skincolor")
    //.GetReference("User/"+uId)
    .GetValueAsync().ContinueWith(task =>
    {
        if (task.IsFaulted)
        {
            Debug.Log("error");
            // Handle the error...
        }
        else if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;
            j = snapshot.GetRawJsonValue();
            //Debug.Log(j);
            skinId = int.Parse(j);
            // Do something with snapshot...
        }
    });
        FirebaseDatabase.DefaultInstance
    .GetReference("User/" + RootName + "/HairId") //แทน key ด้วย uId 
                                                  //.GetReference("User/"+uId)
    .GetValueAsync().ContinueWith(task =>
    {
        if (task.IsFaulted)
        {
            Debug.Log("error");
            // Handle the error...
        }
        else if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;
            j = snapshot.GetRawJsonValue();
            //Debug.Log(j);
            hairId = int.Parse(j);
            // Do something with snapshot...
        }
    });

        FirebaseDatabase.DefaultInstance
    .GetReference("User/" + RootName + "/Gender") //แทน key ด้วย uId 
                                                  //.GetReference("User/"+uId)
    .GetValueAsync().ContinueWith(task =>
    {
        if (task.IsFaulted)
        {
            Debug.Log("error");
            // Handle the error...
        }
        else if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;
            j = snapshot.GetRawJsonValue();
            //Debug.Log(j);
            gender = int.Parse(j);
            // Do something with snapshot...
        }
    });

        FirebaseDatabase.DefaultInstance
    .GetReference("User/" + RootName + "/ClothId") //แทน key ด้วย uId 

    //.GetReference("User/"+uId)
    .GetValueAsync().ContinueWith(task =>
    {
        if (task.IsFaulted)
        {
            Debug.Log("error");
            // Handle the error...
        }
        else if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;
            j = snapshot.GetRawJsonValue();
            Debug.Log(j);
            clothId = int.Parse(j);
            // Do something with snapshot...
        }
    });


        // อ่าน Key เพื่อใช้แสดงผล
        //string uId = FirebaseApp.DefaultInstance.GetEditorAuthUserId();
        //Debug.Log(uId);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bOptions.Length; i++)
        {
            if (i == gender)
            {
                body.sprite = bOptions[i];
            }
        }
        for (int i = 0; i < colors.Length; i++)
        {
            if (i == skinId)
            {
                skin.color = colors[i];
            }
        }

        if (gender == 0)
        {
            for (int i = 0; i < girlcOptions.Length; i++)
            {
                if (i == clothId)
                {
                    cloth.sprite = girlcOptions[i];
                }
            }
            for (int i = 0; i < girlhOptions.Length; i++)
            {
                if (i == hairId)
                {
                    hair.sprite = girlhOptions[i];
                }
            }
        }
        if (gender == 1)
        {
            for (int i = 0; i < boycOptions.Length; i++)
            {
                if (i == clothId)
                {
                    cloth.sprite = boycOptions[i];
                }
            }
            for (int i = 0; i < boyhOptions.Length; i++)
            {
                if (i == hairId)
                {
                    hair.sprite = boyhOptions[i];
                }
            }
        }

       
    }

    public void ChangeCloth(int cId)
    {
        clothId = cId;
        Debug.Log("clothId : " + clothId);
    }

    public void ChangeHair(int hId)
    {
        hairId = hId;
        Debug.Log("hairId : " + hairId);
    }

    public void UpdateValue()
    {
        Debug.Log("RootName : " + RootName);
        reference.Child("User/" + RootName).Child("ClothId").SetValueAsync(clothId);
        reference.Child("User/" + RootName).Child("HairId").SetValueAsync(hairId);

    }

}
