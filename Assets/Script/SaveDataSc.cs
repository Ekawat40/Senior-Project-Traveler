using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SaveDataSc : MonoBehaviour {

    //public TextMesh textValue;
    public Text textValue;

    int healthValue = 0;

    public void Save()
    {
        PlayerPrefs.SetInt("HealthKey", healthValue);
    }

    public void Load()
    {
        healthValue = PlayerPrefs.GetInt("HealthKey", 0);
        //PlayerPrefs.SetInt("HealthKey", 0);
        if (PlayerPrefs.HasKey("HealthKEy"))
        {
            //do something
        }
        textValue.text = healthValue.ToString();
    }

    public void Delete()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("HealthKey");
    }

    public void Increase()
    {
        healthValue++;
        textValue.text = healthValue.ToString();
    }
}
