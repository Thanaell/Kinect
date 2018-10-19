using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwippingRight : Gesture
{


    [SerializeField]
    float deltaX = 0.1f;

    [SerializeField]
    float deltaY = 0.1f;

    [SerializeField]
    float distanceMaxX = 0.4f;


    public GameObject epauleDroite;
    public GameObject coudeDroit;
    public GameObject mainDroite;

    bool FirstPosition;
    float timerLeftRight;
    bool SecondPosition;
    float timerRightLeft;

    public override void localStart()
    {
        FirstPosition = false;
        timerLeftRight = 0;
        SecondPosition = false;
        timerRightLeft = 0;
    }

    public override void detect()
    {

        if (Mathf.Abs(epauleDroite.transform.position.x - mainDroite.transform.position.x) < deltaX)
        {
            if (SecondPosition)
            {
                isDetected = true;
                SecondPosition = false;
                timerRightLeft = 0;
            }
            FirstPosition = true;
            timerLeftRight = gestureTime;

        }
        if (timerLeftRight > 0)
        {
            timerLeftRight-=Time.deltaTime;
        }
        else
        {
            timerLeftRight = 0;
            FirstPosition = false;
        }
        
        if (Mathf.Abs(coudeDroit.transform.position.y - mainDroite.transform.position.y) < deltaY &
            Mathf.Abs(epauleDroite.transform.position.y - coudeDroit.transform.position.y) < deltaY &
            mainDroite.transform.position.x - epauleDroite.transform.position.x > distanceMaxX &
             FirstPosition)
        {
            FirstPosition = false;
            timerLeftRight = 0;
            timerRightLeft = gestureTime;
            SecondPosition = true;
        }
        if (timerRightLeft > 0)
        {
           timerRightLeft-=Time.deltaTime;
        }
        else
        {
            timerRightLeft = 0;
            SecondPosition = false;
        }

    }


}
