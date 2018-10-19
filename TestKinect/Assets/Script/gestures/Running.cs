using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : Gesture {
 
    [SerializeField]
    float deltaX = 0.1f;

    [SerializeField]
    float deltaY = 0.1f;


    public GameObject epauleDroite;
    public GameObject coudeDroit;
    public GameObject mainDroite;

    public GameObject epauleGauche;
    public GameObject coudeGauche;
    public GameObject mainGauche;

    bool FirstPosition;
    float timerBackwardForward;
    bool SecondPosition;
    float timerForwardBackward;
    bool ThirdPosition;
    float FinalTimer;

    public override void localStart()
    {
        FirstPosition = false;
        SecondPosition = false;
        ThirdPosition = false;
    }

    public override void detect()
    {
        if (Mathf.Abs(coudeDroit.transform.position.x - mainDroite.transform.position.x) < deltaX &
            Mathf.Abs(coudeDroit.transform.position.y - mainDroite.transform.position.y) < deltaY &
            epauleDroite.transform.position.y > coudeDroit.transform.position.y + deltaY &
            Mathf.Abs(epauleDroite.transform.position.x - coudeDroit.transform.position.x) < deltaX &
            Mathf.Abs(epauleGauche.transform.position.x - mainGauche.transform.position.x) < deltaX &
            Mathf.Abs(epauleGauche.transform.position.y - mainGauche.transform.position.y) < deltaY &
            epauleGauche.transform.position.y > coudeGauche.transform.position.y + deltaY &
            Mathf.Abs(epauleGauche.transform.position.x - coudeGauche.transform.position.x) < deltaX)
        {
            if (SecondPosition)
            {

                SecondPosition = false;
                timerForwardBackward = 0;
                ThirdPosition = true;
                FinalTimer = gestureTime;
            }
            FirstPosition = true;
            timerBackwardForward = gestureTime;
            

        }
        if (timerBackwardForward > 0)
        {
            timerBackwardForward-=Time.deltaTime;
        }
        else
        {
            timerBackwardForward = 0;
            FirstPosition = false;
        }
        if (FinalTimer >0)
        {
            FinalTimer -= Time.deltaTime; 
        }
        else
        {
            FinalTimer = 0;
            ThirdPosition = false;
        }

        if (Mathf.Abs(epauleDroite.transform.position.x - mainDroite.transform.position.x) < deltaX &
                Mathf.Abs(epauleDroite.transform.position.y - mainDroite.transform.position.y) < deltaY &
                epauleDroite.transform.position.y > coudeDroit.transform.position.y + deltaY &
                Mathf.Abs(epauleDroite.transform.position.x - coudeDroit.transform.position.x) < deltaX &
                
                Mathf.Abs(coudeGauche.transform.position.x - mainGauche.transform.position.x) < deltaX &
                Mathf.Abs(coudeGauche.transform.position.y - mainGauche.transform.position.y) < deltaY &
                epauleGauche.transform.position.y > coudeGauche.transform.position.y + deltaY &
                Mathf.Abs(epauleGauche.transform.position.x - coudeGauche.transform.position.x) < deltaX)
        {
            if (FirstPosition)
            {
                SecondPosition = true;
                timerForwardBackward = gestureTime;
                FirstPosition = false;
                timerBackwardForward = 0;
            }
            if (ThirdPosition)
            {
                isDetected = true;
                ThirdPosition = false;
                FinalTimer = 0;
            }
        }
        if (timerForwardBackward > 0)
        {
                timerForwardBackward-=Time.deltaTime;
              
        }
        else
        {
                timerForwardBackward = 0;
                SecondPosition = false;
        }

        
    }

}
