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


    public override void localStart()
    {
    }

    public override void detect()
    {


        if (Mathf.Abs(mainDroite.transform.position.z - coudeDroit.transform.position.z) > distanceMaxZ/2 &
            Mathf.Abs(coudeDroit.transform.position.z - epauleDroite.transform.position.z) > distanceMaxZ/2 )
        {
            
            isDetected = true;
        }

    }

}
