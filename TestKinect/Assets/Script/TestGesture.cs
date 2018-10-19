using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGesture : Gesture {
    //nombre de points prelevé pour considerer l'action SwippingLeft
    [SerializeField]
    int PointNumberAction = 100;

    [SerializeField]
    float deltaY = 0.08f;

    [SerializeField]
    float margeTeteY = 0.01f;

    public GameObject tete;
    public GameObject mainDroite;
    public GameObject mainGauche;

    int compteurDownUp;
    int compteurUpDown;

    bool isUp;
    bool isDown;
    

    public override void localStart()
    {
        compteurDownUp = 0;
        compteurUpDown = 0;
        isUp = false;
        isDown = false;
    }

    public override void detect()
    {
        if (Mathf.Abs(mainDroite.transform.position.y-mainGauche.transform.position.y)<deltaY &
            mainDroite.transform.position.y<tete.transform.position.y-margeTeteY &
            mainGauche.transform.position.y < tete.transform.position.y - margeTeteY)
        {
            if (isUp)
            {
                isDetected = true;
                compteurUpDown = 0;
                isUp = false;
            }
            isDown = true;
            compteurDownUp = PointNumberAction / 2;
        }
        if (compteurDownUp > 0)
        {
            compteurDownUp--;
        }
        else
        {
            compteurDownUp = 0;
            isDown = false;
        }

        if (Mathf.Abs(mainDroite.transform.position.y - mainGauche.transform.position.y) < deltaY &
            mainDroite.transform.position.y > tete.transform.position.y + margeTeteY &
            mainGauche.transform.position.y > tete.transform.position.y + margeTeteY &
            isDown)
        {
           
            isDown = false;
            compteurDownUp = 0;
            compteurUpDown = PointNumberAction / 2;
            isUp = true;
        }

    }

}
