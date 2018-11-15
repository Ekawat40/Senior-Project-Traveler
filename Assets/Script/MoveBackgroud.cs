using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    public float bgSpeed;
    float bgPositionX;
    float bg1PositionX;


	// Use this for initialization
	void Start () {
        bgPositionX = transform.position.x;
        bg1PositionX = GameObject.Find("backgroud_1").transform.position.x;
        

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + bgSpeed, transform.position.y, transform.position.z);
        if ( transform.position.x < (bg1PositionX * -1f))
        {
            transform.position = new Vector3(bg1PositionX, transform.position.y, transform.position.z);
        }

    }
}
