using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PedometerU.Tests;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class CountryMap : SwapBg
{

    private DatabaseReference reference;
    string i;
    int num;
    // public Button level02Button, level03Button;

    [SerializeField]
    GameObject btnDes1, btnDes2, btnDes3, btnDes4, btnDes5, btnDes6, btnDes7, btnDes8, btnDes9, btnDes10;

    int tempValue = 0;
    // Use this for initialization
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
        // สำหรับใช้ในการอ้างอิง Firebase
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        setName();
        /*int levelPassed;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level02Button.interactable = false;
        level03Button.interactable = false;*/

        /*switch (levelPassed)        { // ถ้า levelPassed = 1 จะปลดล็อคlevleของด่านที่2  , ถ้า levelPassed = 2 จะปลดล็อคlevleของด่านที่ 2 กับ 3
            case 1:
			level02Button.interactable = true;
			break;
		case 2:
			level02Button.interactable = true;
			level03Button.interactable = true;
			break;
		}*/

        /*switch (money)
        { // ถ้า levelPassed = 1 จะปลดล็อคlevleของด่านที่2  , ถ้า levelPassed = 2 จะปลดล็อคlevleของด่านที่ 2 กับ 3
            case 5:
                level02Button.interactable = true;
                break;
            case 10:
                level02Button.interactable = true;
                level03Button.interactable = true;
                break;
        }*/
        setState();
        //Load();
        Debug.Log(temp);

        ////////////////////////////////


        /*if (tempValue == 1)
        {
            Destroy(btnDes1);
        }

        if (tempValue == 2)
        {
            Destroy(btnDes1);
            Destroy(btnDes2);
        }*/

         FirebaseDatabase.DefaultInstance
        .GetReference("User/" + RootName + "/Country")
        .GetValueAsync().ContinueWith(task =>
        {
        if (task.IsFaulted)
        {
            Debug.Log("error");
        }
        else if (task.IsCompleted)
        {
            DataSnapshot snapshot = task.Result;
                i = snapshot.GetRawJsonValue();
                num = int.Parse(i);
                    }
        });



    }

    public void Load()
    {
        tempValue = PlayerPrefs.GetInt("tempKey", 0);
        //PlayerPrefs.SetInt("HealthKey", 0);
    }


    private void Update()
    {
        /*switch (money)
        { // ถ้า levelPassed = 1 จะปลดล็อคlevleของด่านที่2  , ถ้า levelPassed = 2 จะปลดล็อคlevleของด่านที่ 2 กับ 3
            case 5:
                level02Button.interactable = true;
                money = money - 5;
                break;
            case 10:
                level02Button.interactable = true;
                level03Button.interactable = true;
                money = money - 10;
                break;
        }*/

        // SwapBg swapBg = new SwapBg();

        /*if (temp == 1)
        {
            tempValue = temp;
            //PlayerPrefs.SetInt("tempKey", tempValue);
            Destroy(btnDes1);
        }

        if (temp == 2)
        {
            tempValue = temp;
            //PlayerPrefs.SetInt("tempKey", tempValue);
            Destroy(btnDes1);
            Destroy(btnDes2);
        }*/

        if (num == 1)
        {
            Destroy(btnDes1);
        }

        if (num == 2)
        {
            Destroy(btnDes1);
            Destroy(btnDes2);
        }


    }

    /*public void levelToLoad (int level)
	{
		SceneManager.LoadScene (level);
	}*/

    /*public void resetPlayerPrefs() // reset-level   
    {
		level02Button.interactable = false; // ถ้าเป็น flase = ยังไม่ปลดล็อคlevel 
		level03Button.interactable = false; // ถ้าเป็น flase = ยังไม่ปลดล็อคlevel 
        PlayerPrefs.DeleteAll ();
	}*/




}
