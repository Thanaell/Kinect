using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch :  Gesture
{


    //nombre de points prelevé pour considerer l'action SwippingLeft
    [SerializeField]
    int PointNumberAction = 50;

    [SerializeField]
    float deltaX = 0.1f;

    [SerializeField]
    float deltaY = 0.1f;


    public GameObject epauleDroite;
    public GameObject coudeDroite;
    public GameObject mainDroite;

    bool FirstPosition;
    int compteurBackwardForward=0;

    public override void localStart()
    {
        FirstPosition = false;
    }

    public override void detect()
    {
        
            if (Mathf.Abs(epauleDroite.transform.position.x - mainDroite.transform.position.x) < deltaX &
                Mathf.Abs(epauleDroite.transform.position.y - mainDroite.transform.position.y) < deltaY &
                epauleDroite.transform.position.y > coudeDroite.transform.position.y + deltaY &
                Mathf.Abs(epauleDroite.transform.position.x - coudeDroite.transform.position.x) < deltaX)
            {
                FirstPosition = true;
                compteurBackwardForward = PointNumberAction ;

            }
            if (compteurBackwardForward > 0)
            {
                compteurBackwardForward--;
            }
            else
            {
                compteurBackwardForward = 0;
                FirstPosition = false;
            }

            if (Mathf.Abs(coudeDroite.transform.position.x - mainDroite.transform.position.x) < deltaX &
                Mathf.Abs(coudeDroite.transform.position.y - mainDroite.transform.position.y) < deltaY &
                Mathf.Abs(epauleDroite.transform.position.x - coudeDroite.transform.position.x) < deltaX &
                Mathf.Abs(epauleDroite.transform.position.y - coudeDroite.transform.position.y) < deltaY &
                FirstPosition)
            {
                isDetected = true;
                FirstPosition = false;
                compteurBackwardForward = 0;
            }

        
    }

}
