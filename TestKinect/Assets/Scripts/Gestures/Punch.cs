using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : Gesture
{

    [SerializeField]
    float deltaZ = 0.1f;


    [SerializeField]
    float distanceMaxZ = 0.4f;


    public GameObject epauleDroite;
    public GameObject coudeDroit;
    public GameObject mainDroite;

    bool FirstPosition;
    float timerLeftRight;

    public override void localStart()
    {
        FirstPosition = false;
        timerLeftRight = 0;
    }

    public override void detect()
    {

        if (Mathf.Abs(epauleDroite.transform.position.z - mainDroite.transform.position.z) < deltaZ)
        {
            Debug.Log("true");
            FirstPosition = true;
            timerLeftRight = gestureTime;

        }
        if (timerLeftRight > 0)
        {
            timerLeftRight -= Time.deltaTime;
        }
        else
        {
            timerLeftRight = 0;
            FirstPosition = false;
        }

        if (mainDroite.transform.position.z - coudeDroit.transform.position.z > distanceMaxZ &
            coudeDroit.transform.position.z - epauleDroite.transform.position.z > distanceMaxZ &
             FirstPosition)
        {
            FirstPosition = false;
            timerLeftRight = 0;
            isDetected = true;
        }

    }

}
