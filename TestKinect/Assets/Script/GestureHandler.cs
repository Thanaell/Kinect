using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestureHandler : MonoBehaviour {
    [SerializeField]
    private Text text;
	// Use this for initialization
	void Start () {
        text.text = "No Gesture";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GestureDisplay(System.Type type)
    {
        text.text = type.ToString();
        Debug.Log(type);
    }
}
