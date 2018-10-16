using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGesture : Gesture {
    //nombre de frame
    [SerializeField]
    int FrameNumber = 5;

    //nombre de points moyens prelevé pour considerer un geste 
    [SerializeField]
    int PointNumberSwippe = 4;

    //nombre de points prelevé pour considerer l'action SwippingLeft
    [SerializeField]
    int PointNumberAction = 20;

    [SerializeField]
    float deltaX = 0.01f;

    [SerializeField]
    float deltaY = 0.01f;


    public GameObject epauleDroite;
    public GameObject coudeDroite;
    public GameObject mainDroite;

    public override void localStart()
    {

    }

    public override void detect()
    {

    }

}
