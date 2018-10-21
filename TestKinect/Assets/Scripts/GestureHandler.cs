using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestureHandler : MonoBehaviour {
    [SerializeField]
    private Text text;
    [SerializeField]
    private float coolDown = 3;
    private float timer;
    // Use this for initialization
    void Start () {
        text.text = "No Gesture";
	}
	
	// Update is called once per frame
	void Update () {
		
        if (timer <= 0)
        {
            text.text = "No gesture";
            timer = 0;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void GestureDisplay(System.Type type)
    {
        if (timer <= 0)
        {
            timer = coolDown;

            string myType = type.ToString();
            switch (myType)
            {
                case "Closing":
                    SceneManager.LoadScene(0);
                    break;
                default:
                    text.text = type.ToString();
                    break;
            }
        }
    }
}
