using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class loadingScene : RootControl
{

    private DatabaseReference reference;
    string i;
    int state;

    // Use this for initialization
    void Start () {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        setName();

        FirebaseDatabase.DefaultInstance
        .GetReference("User/" + RootName + "/State")
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
                state = int.Parse(i);

            }
        });

        StartCoroutine(LoadNewScene());

        /* if(state == 0)
         {
             SceneManager.LoadScene("ChooseGender");
         }
         else if(state == 1)
         {
             SceneManager.LoadScene("mockupmaincharacter");
         }*/
    }

    IEnumerator LoadNewScene()
    {

        yield return new WaitForSeconds(2);
        AsyncOperation async;
        if (state == 0)
        {
           // SceneManager.LoadScene("ChooseGender");
            async = SceneManager.LoadSceneAsync("ChooseGender");
            while (!async.isDone)
            {
                yield return null;
            }
        }
        else if (state == 1)
        {
            async = SceneManager.LoadSceneAsync("mockupmaincharacter");
            while (!async.isDone)
            {
                yield return null;
            }
           // SceneManager.LoadScene("mockupmaincharacter");
        }

    }


    // Update is called once per frame
    void Update () {
		
	}
}
