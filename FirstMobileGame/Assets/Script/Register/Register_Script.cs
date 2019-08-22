using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Register_Script : MonoBehaviour {

    public Text time_text;

    [SerializeField]
    string get_time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        get_time = System.DateTime.Now.ToString();
        time_text.text = get_time;

	}
}
