using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnection : MonoBehaviour {
    [SerializeField]
    private GameObject objectTest;
	// Use this for initialization
	void Start () {
        objectTest = GameObject.Find("TestConnection");
	}
	
	// Update is called once per frame
	void Update () {
		if (objectTest.transform.position ==transform.position)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
	}
}
