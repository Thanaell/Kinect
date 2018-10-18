using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closing : Gesture{
    

    //nombre de points prelevé pour considerer l'action SwippingLeft
    [SerializeField]
    int PointNumberAction = 30;

    [SerializeField]
    float deltaX = 0.05f;

    [SerializeField]
    float disctanceMaxX= 1f;

    [SerializeField]
    float deltaY = 0.1f;

    
    public GameObject mainDroite;
    
    public GameObject mainGauche;

    bool FirstPosition;
    int compteurOpenClose;

    public override void localStart()
    {
        FirstPosition = false;
        compteurOpenClose = 0;
    }

    public override void detect()
    {

        if (mainDroite.transform.position.x-mainGauche.transform.position.x > disctanceMaxX &
            Mathf.Abs(mainDroite.transform.position.y-mainGauche.transform.position.y)<deltaY)
        {

            FirstPosition = true;
            compteurOpenClose = PointNumberAction ;

        }
        if (compteurOpenClose > 0)
        {
            compteurOpenClose--;
        }
        else
        {
            compteurOpenClose = 0;
            FirstPosition = false;
        }

        if (Mathf.Abs(mainDroite.transform.position.x-mainGauche.transform.position.x)<deltaX &
           Mathf.Abs(mainDroite.transform.position.y - mainGauche.transform.position.y) < deltaY &
           FirstPosition)
        {
            //Debug.Log("second");
            FirstPosition = false;
            isDetected = true;
            compteurOpenClose = 0;

        }

    }
}
