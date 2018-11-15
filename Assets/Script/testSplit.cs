using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSplit : MonoBehaviour {

	// Use this for initialization
	void Start () {

        string[] separatingChars = { "@" };

        string text = "aekwatt@gmail.com";
        System.Console.WriteLine("Original text: '{0}'", text);

        string[] words = text.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
        System.Console.WriteLine("{0} substrings in text:", words.Length);

            Debug.Log(words[0]);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
