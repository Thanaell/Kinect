using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    int i;
    int compteurRight;
    int compteurLeft;
    float xpositionPrevious;
    float xpositionCurrent;
    int compteurRightLeft;

    float[] positions = new float[5];

    public GameObject e;
    public GameObject m;


    // Use this for initialization
    void Start () {
        transform.position += new Vector3(1, 0, 0);


        i = 0;
        compteurRight = 0;
        compteurLeft = 0;
        xpositionPrevious = m.transform.position.x - e.transform.position.x ;
        xpositionCurrent = xpositionPrevious;
        compteurRightLeft = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (compteurRight >= 5)
        {
            Debug.Log("you swiped right");
            compteurRight = 0;
            compteurRightLeft = 20;
        }
        if (compteurLeft >= 5)
        {
            Debug.Log("you swiped left");
            compteurLeft = 0;
            if (compteurRightLeft > 0)
            {
                Debug.Log("double");
            }
        }

        // échantillon toutes les 5 frames
        if (i == 5)
        {
            i = 0;
            xpositionPrevious = xpositionCurrent;
            xpositionCurrent = 0;
            for (int j = 0; j < 5; j++)
            {
                xpositionCurrent += positions[j];
            }
            xpositionCurrent = xpositionCurrent / 5;
            
            if (xpositionCurrent > xpositionPrevious + 0.01)
            {
                compteurRight++;
            }
            else if (xpositionCurrent < xpositionPrevious)
            {
                compteurRight = 0;
            }
            if (xpositionCurrent < xpositionPrevious - 0.01)
            {
                compteurLeft++;
            }
            else if (xpositionCurrent > xpositionPrevious)
            {
                compteurLeft = 0;
            }
            if (compteurRightLeft > 0)
            {
                compteurRightLeft--;
            }
        }
        positions[i] = m.transform.position.x - e.transform.position.x;
        i++;
    }

    
}
