using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBg : MonoBehaviour {


    public float bgSpeed;
    float bgPositionX = 0;
    float bg1PositionX = 0;


    // Use this for initialization
    void Start()
    {
        bgPositionX = transform.position.x;
        bg1PositionX = GameObject.Find("Bg").transform.position.x;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + bgSpeed, transform.position.y, transform.position.z);
        if (transform.position.x < (bg1PositionX * -1f))
        {
            transform.position = new Vector3(bg1PositionX, transform.position.y, transform.position.z);
        }

    }



}
