using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : RootControl
{

    public GameObject Panel;


    public GameObject BtnCity;
    string i;
    private int num, numBg, numMoney;
    public Text stepText;
    private DatabaseReference reference;

    public GameObject BtnLock;




    // Use this for initialization
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
        // สำหรับใช้ในการอ้างอิง Firebase
        reference = FirebaseDatabase.DefaultInstance.RootReference;


        setName();
                FirebaseDatabase.DefaultInstance
        .GetReference("User/" + RootName + "/Money")
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
             numMoney = int.Parse(i);
             //stepText.text = numMoney.ToString();
             
                    }
        });



        Panel.SetActive(false);
    }
    public void changePanelState(bool state)
    {
        Panel.SetActive(state);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CheckCharacterHistory()
    {

    }
    public void ChangeSceneGirl()
    {
        SceneManager.LoadScene("CreateCharacter");
    }
    public void ChangeSceneBoy()
    {
        SceneManager.LoadScene("CreateBoyCharacter");
    }
    public void ChangeSceneGender()
    {
        SceneManager.LoadScene("ChooseGender");
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void DecreaseMoney()
    {


        if (numMoney >= 10)
        {
            numMoney = int.Parse(i) - 10;
           // stepText.text = numMoney.ToString();
            reference.Child("User/" + RootName).Child("Money").SetValueAsync(numMoney);
            Destroy(BtnCity);
        }

        //Destroy(BtnLock);
    }
}
