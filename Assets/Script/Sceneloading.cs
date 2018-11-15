using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sceneloading : MonoBehaviour {

    [SerializeField]
    GameObject panel1;

    // Use this for initialization
    void Start () {
        StartCoroutine(LoadNewScene());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LoadNewScene()
    {

        yield return new WaitForSeconds(3);

        Destroy(panel1);
    }
}
