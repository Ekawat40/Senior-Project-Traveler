using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneControl : MonoBehaviour {

    public void ChangeSceneGirl()
    {
        SceneManager.LoadScene("CreateGirlCharacter");
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
}
