using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveLocation : MonoBehaviour {

    // position
    public float thisCharactersXposition;
    public float thisCharactersYposition;
    public float thisCharactersZposition;

    //rotation
    public float thisCharactersXrotation;
    public float thisCharactersYrotation;
    public float thisCharactersZrotation;


    
  
    //Get value for current position and rotation.
    public void Awake()  {
        thisCharactersXposition = PlayerPrefs.GetFloat("MyPositionX");
        thisCharactersYposition = PlayerPrefs.GetFloat("MyPositionY");
        thisCharactersZposition = PlayerPrefs.GetFloat("MyPositionZ");



          thisCharactersXrotation = PlayerPrefs.GetFloat("MyRotationX");
          thisCharactersYrotation = PlayerPrefs.GetFloat("MyRotationY");
          thisCharactersZrotation = PlayerPrefs.GetFloat("MyRotationZ");

    }


    //Set value for current position and rotation.
    public void Start()  {
        transform.position = new Vector3(thisCharactersXposition,thisCharactersYposition, thisCharactersZposition) ;  //set the position our transform.
        transform.rotation = Quaternion.Euler(thisCharactersXrotation, thisCharactersYrotation , thisCharactersZposition);  //set the rotation our transform.

    }


    //Save value of the current position and rotation every frame.
    public void Update()  {

        PlayerPrefs.SetFloat("MyPositionX", transform.position.x);
        PlayerPrefs.SetFloat("MyPositionY", transform.position.y);
        PlayerPrefs.SetFloat("MyPositionZ", transform.position.z);

          PlayerPrefs.SetFloat("MyRotationX", transform.eulerAngles.x);
          PlayerPrefs.SetFloat("MyRotationY", transform.eulerAngles.y);
          PlayerPrefs.SetFloat("MyRotationZ", transform.eulerAngles.z);


    }



}
