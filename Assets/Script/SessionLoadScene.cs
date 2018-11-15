using PedometerU.Tests;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SessionLoadScene : MonoBehaviour
{


    public Button SeesionBtn;
    Scene sceneM;
    //
    //public String RootName;

    // Use this for initialization
    void Start () {
        if (sceneM.name == "LogoStart")
        {
            SeesionBtn.onClick.AddListener(() => SessionLoad());
            
        }

       // getRoot();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SessionLoad()
    {

        /*if (RootName != null)
        {
            Debug.Log(RootName);
            SceneManager.LoadScene("mockupmaincharacter");
        }
        else if (RootName == null)
        {
            SceneManager.LoadScene("Login");
        }*/

       /* if (RootName == null)
        {
            SceneManager.LoadScene("Login");
        }
        else
        {

        }*/

       // SSTools.ShowMessage(RootName, SSTools.Position.bottom, SSTools.Time.twoSecond);
    }

    public void ClearSession()
    {
      //  RootName = null;
        PlayerPrefs.DeleteKey("RootKey");
    }
}
