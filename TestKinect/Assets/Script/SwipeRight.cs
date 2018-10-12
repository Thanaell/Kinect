using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRight : MonoBehaviour {
    int i;
    int compteurRight;
    int compteurLeft;
    float xpositionPrevious;
    float xpositionCurrent;
    float [] positions;
    int erreur;
	// Use this for initialization
	void Start () {
        i = 0;
        compteurRight = 0;
        compteurLeft = 0;
        xpositionPrevious = transform.position.x;
        xpositionCurrent = transform.position.x;
        positions = new float[5];
    }
	
	// Update is called once per frame
	void Update () {
        if (compteurRight >= 3)
        {
            Debug.Log("you swiped right");
            compteurRight = 0;
        }

        // échantillon toutes les 5 frames
    
            if (compteurRight != 0)
            {
                Debug.Log(transform.position.x + " compteur : " +compteurRight);
            }
            xpositionPrevious = xpositionCurrent;
            xpositionCurrent = transform.position.x;
            if (xpositionCurrent > xpositionPrevious+0.01)
            {
                compteurRight++;
            }
            else if (xpositionCurrent < xpositionPrevious)
            {
                compteurRight = 0;
            }
        
	}
}
