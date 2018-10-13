using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnection : MonoBehaviour {
    public Rigidbody objectTest;
	// Use this for initialization
	void Start () {
        objectTest = GameObject.Find("TestConnection").GetComponent < Rigidbody >();
	}
	
	// Update is called once per frame
	void Update () {
		if (objectTest.velocity == new Vector3(0,0,0))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
	}
}
