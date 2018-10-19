using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closing : Gesture{

    [SerializeField]
    float deltaX = 0.05f;

    [SerializeField]
    float disctanceMaxX= 0.8f;

    [SerializeField]
    float deltaY = 0.1f;

    
    public GameObject mainDroite;
    
    public GameObject mainGauche;

    bool FirstPosition;
    float timerOpenClose;

    public override void localStart()
    {
        FirstPosition = false;
        timerOpenClose = 0;
    }

    public override void detect()
    {

        if (mainDroite.transform.position.x-mainGauche.transform.position.x > disctanceMaxX &
            Mathf.Abs(mainDroite.transform.position.y-mainGauche.transform.position.y)<deltaY)
        {

            FirstPosition = true;
            timerOpenClose = gestureTime ;

        }
        if (timerOpenClose > 0)
        {
            timerOpenClose-=Time.deltaTime;
        }
        else
        {
            timerOpenClose = 0;
            FirstPosition = false;
        }

        if (Mathf.Abs(mainDroite.transform.position.x-mainGauche.transform.position.x)<deltaX &
           Mathf.Abs(mainDroite.transform.position.y - mainGauche.transform.position.y) < deltaY &
           FirstPosition)
        {
            FirstPosition = false;
            isDetected = true;
            timerOpenClose = 0;

        }

    }
}
