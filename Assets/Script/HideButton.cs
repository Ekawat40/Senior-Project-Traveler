using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HideButton : MonoBehaviour {


    public GameObject Btn1;
    public GameObject Btn2;

    public void changePanelState(bool state)
    {
        Btn1.SetActive(state);
        Btn2.SetActive(state);
        
    }

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
