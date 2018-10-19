using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        string myType = type.ToString();
        switch (myType)
        {
            case "Closing": SceneManager.LoadScene(0);
                break;
            default: text.text = type.ToString();
                break;
        }    
    }
}
