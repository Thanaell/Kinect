using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGesture : Gesture {



    //nombre de points prelevé pour considerer l'action SwippingLeft
    [SerializeField]
    int PointNumberAction = 50;

    [SerializeField]
    float deltaX = 0.1f;

    [SerializeField]
    float deltaY = 0.05f;

    [SerializeField]
    float distanceMaxX = 0.1f;


    public GameObject epauleDroite;
    public GameObject coudeDroit;
    public GameObject mainDroite;

    bool FirstPosition;
    int compteurLeftRight ;
    bool SecondPosition;
    int compteurRightLeft;

    public override void localStart()
    {
        FirstPosition = false;
        compteurLeftRight = 0;
        SecondPosition = false;
        compteurRightLeft = 0;
    }

    public override void detect()
    {

        if (Mathf.Abs(epauleDroite.transform.position.x - mainDroite.transform.position.x) < deltaX )
        {
            if (SecondPosition)
            {
                isDetected = true;
                SecondPosition = false;
                compteurRightLeft = 0;
            }
            FirstPosition = true;
            compteurLeftRight = PointNumberAction/2;

        }
        if (compteurLeftRight> 0)
        {
            compteurLeftRight--;
        }
        else
        {
            compteurLeftRight = 0;
            FirstPosition = false;
        }

        if (Mathf.Abs(coudeDroit.transform.position.y - mainDroite.transform.position.y) < deltaY &
            Mathf.Abs(mainDroite.transform.position.y - coudeDroit.transform.position.y) < deltaY &
            epauleDroite.transform.position.x-mainDroite.transform.position.x>distanceMaxX &
            FirstPosition)
        {
            FirstPosition = false;
            compteurLeftRight = 0;
            compteurRightLeft = PointNumberAction / 2;
            SecondPosition = true;
        }
        if (compteurRightLeft > 0)
        {
            compteurRightLeft--;
        }
        else
        {
            compteurRightLeft = 0;
            SecondPosition = false;
        }

    }


}
