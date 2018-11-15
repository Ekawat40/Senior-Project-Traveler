using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManuControlScript : MonoBehaviour {

	public Button level02Button, level03Button;


    int money = 0;



	// Use this for initialization
	void Start () {
        int levelPassed;
        levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		level02Button.interactable = false;
		level03Button.interactable = false;

        /*switch (levelPassed)        { // ถ้า levelPassed = 1 จะปลดล็อคlevleของด่านที่2  , ถ้า levelPassed = 2 จะปลดล็อคlevleของด่านที่ 2 กับ 3
            case 1:
			level02Button.interactable = true;
			break;
		case 2:
			level02Button.interactable = true;
			level03Button.interactable = true;
			break;
		}*/

        switch (money)
        { // ถ้า levelPassed = 1 จะปลดล็อคlevleของด่านที่2  , ถ้า levelPassed = 2 จะปลดล็อคlevleของด่านที่ 2 กับ 3
            case 5:
                level02Button.interactable = true;
                break;
            case 10:
                level02Button.interactable = true;
                level03Button.interactable = true;
                break;
        }

    }


    private void Update()
    {
        switch (money)
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


    public void addMoney()
    {
        money = money+1;

    }


}
