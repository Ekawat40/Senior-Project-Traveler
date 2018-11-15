using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public void ChangeScene()
    {
        SceneManager.LoadScene("MapCountry");
    }

    public void ChangeDecorateCity1()
    {
        SceneManager.LoadScene("DecorateCity2");
    }

    public void ChangeDecorateCity2()
    {
        SceneManager.LoadScene("DecorateCity2.1");
    }

    public void ChangeDecorateCity3()
    {
        SceneManager.LoadScene("DecorateCity2.3");
    }
}
