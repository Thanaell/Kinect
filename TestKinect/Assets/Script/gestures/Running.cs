using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : Gesture {
 

    //nombre de points prelevé pour considerer l'action SwippingLeft
    [SerializeField]
    int PointNumberAction = 120;

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
    int compteurBackwardForward;
    bool SecondPosition;
    int compteurForwardBackward;

    public override void localStart()
    {
        FirstPosition = false;
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
                    isDetected = true;
                    SecondPosition = false;
                    compteurForwardBackward = 0;
                }
                FirstPosition = true;
                compteurBackwardForward = PointNumberAction / 2;

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

            if (Mathf.Abs(epauleDroite.transform.position.x - mainDroite.transform.position.x) < deltaX &
                Mathf.Abs(epauleDroite.transform.position.y - mainDroite.transform.position.y) < deltaY &
                epauleDroite.transform.position.y > coudeDroit.transform.position.y + deltaY &
                Mathf.Abs(epauleDroite.transform.position.x - coudeDroit.transform.position.x) < deltaX &
                FirstPosition &
                Mathf.Abs(coudeGauche.transform.position.x - mainGauche.transform.position.x) < deltaX &
                Mathf.Abs(coudeGauche.transform.position.y - mainGauche.transform.position.y) < deltaY &
                epauleGauche.transform.position.y > coudeGauche.transform.position.y + deltaY &
                Mathf.Abs(epauleGauche.transform.position.x - coudeGauche.transform.position.x) < deltaX)
            {
                //Debug.Log("second");
                SecondPosition = true;
                compteurForwardBackward = PointNumberAction / 2;
                FirstPosition = false;
                compteurBackwardForward = 0;
            }
            if (compteurForwardBackward > 0)
            {
                compteurForwardBackward--;
               // Debug.Log(compteurForwardBackward);
            }
            else
            {
                compteurForwardBackward = 0;
                SecondPosition = false;
            }

        
    }

}
