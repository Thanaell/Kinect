using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwippingUp : Gesture
{

    [SerializeField]
    float deltaY = 0.08f;

    [SerializeField]
    float margeTeteY = 0.01f;

    public GameObject tete;
    public GameObject mainDroite;
    public GameObject mainGauche;

    float timerDownUp;
    float timerUpDown;

    bool isUp;
    bool isDown;


    public override void localStart()
    {
        timerDownUp = 0;
        timerUpDown = 0;
        isUp = false;
        isDown = false;
    }

    public override void detect()
    {
        if (//Mathf.Abs(mainDroite.transform.position.y - mainGauche.transform.position.y) < deltaY &
            mainDroite.transform.position.y < tete.transform.position.y - margeTeteY &
            mainGauche.transform.position.y < tete.transform.position.y - margeTeteY)
        {
            if (isUp)
            {
                isDetected = true;
                timerUpDown = 0;
                isUp = false;
            }
            isDown = true;
            timerDownUp = gestureTime;
        }
        if (timerDownUp > 0)
        {
            timerDownUp-=Time.deltaTime;
        }
        else
        {
            timerDownUp = 0;
            isDown = false;
        }

        if (Mathf.Abs(mainDroite.transform.position.y - mainGauche.transform.position.y) < deltaY &
            mainDroite.transform.position.y > tete.transform.position.y + margeTeteY &
            mainGauche.transform.position.y > tete.transform.position.y + margeTeteY &
            isDown)
        {

            isDown = false;
            timerDownUp = 0;
            timerUpDown = gestureTime;
            isUp = true;
        }

    }

}
