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
        text.text = "Aucun geste détecté";
	}
	
	// Update is called once per frame
	void Update () {
		
        if (timer <= 0)
        {
            text.text = "Aucun geste détecté";
            text.color = Color.white;
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
                case "Punch":
                    text.text = "Coup de poing";
                    break;
                case "SwippingRight":
                    text.text = "Balayage à droite";
                    break;
                case "SwippingLeft":
                    text.text = "Balayage à gauche";
                    break;
                case "SwippingUp":
                    text.text = "Balayage vers le haut";
                    break;
                case "Running":
                    text.text = "Course";
                    break;
                default:
                    text.text = myType;
                    break;
            }
            text.color = Color.green;
        }
    }
}
