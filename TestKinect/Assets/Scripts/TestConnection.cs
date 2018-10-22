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
        connectionText.text = "Pas de Kinect";
        tempPosition = objectTest.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (objectTest.transform.position == tempPosition)
        {
            connectionText.text = "Pas de Kinect";
            connectionText.color = Color.red;
        }
        else
        {
            connectionText.text = "Kinect détectée";
            connectionText.color = Color.green;
        }
        tempPosition = objectTest.transform.position;
	}
}
