using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [SerializeField]
    GameObject btnDes, btnDes2, btnDes3, btnDes4, btnDes5, btnDes6, btnDes7, btnDes8, btnDes9, btnDes10;

    public void btnDestroy()
    {
        Destroy(btnDes);
    }
    public void btnDestroy2()
    {

        Destroy(btnDes2);

    }

    public void btnDestroy3()
    {

        Destroy(btnDes3);

    }

    public void btnCity()
    {
        SceneManager.LoadScene("DecorateCity2");
    }
}
