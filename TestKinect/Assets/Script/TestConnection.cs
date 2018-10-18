using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestConnection : MonoBehaviour {
    [SerializeField]
    private GameObject objectTest;
    [SerializeField]
    private Text connectionText;
    private Vector3 tempPosition;
    // Use this for initialization
    void Start () {
        objectTest = GameObject.Find("TestConnection");
        connectionText.text = "No Kinect";
        tempPosition = objectTest.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (objectTest.transform.position == tempPosition)
        {
            GetComponent<Renderer>().material.color = Color.red;
            connectionText.text = "No Kinect";
            connectionText.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.green;
            connectionText.text = "Kinect detected";
            connectionText.color = Color.green;
        }
        tempPosition = objectTest.transform.position;
	}
}
