using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class SendSc : ChangeAppearances
{

   // public Text email_input;

    

    // Use this for initialization
    void Start () {
        //Load();
        setName();
        Debug.Log(RootName);
        // Debug.Log("SentScript: " + email_input.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
