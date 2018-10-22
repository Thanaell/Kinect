using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestConnection : MonoBehaviour {
    [SerializeField]
    private GameObject objectTest; //Objet qui va bouger comme la main droite
    [SerializeField]
    private Text connectionText;
    private Vector3 tempPosition;
    
    void Start () {
        objectTest = GameObject.Find("TestConnection");
        connectionText.text = "Pas de Kinect";
        tempPosition = objectTest.transform.position;
	}
	
	// A chaque frame, on regarde si l'objet a bougé depuis la frame précédente. Si oui, c'est que le Kinect est connectée
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
