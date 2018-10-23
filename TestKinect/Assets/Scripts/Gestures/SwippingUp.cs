using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwippingUp : Gesture
{
    //l'erreur autorisée en y entre 2 mains
    [SerializeField]
    float deltaY = 0.08f;

    //la distance entre la tête et les mains pour detecter les positions
    [SerializeField]
    float margeTeteY = 0.01f;

    public GameObject tete;
    public GameObject mainDroite;
    public GameObject mainGauche;

    /*les temps entre 2 positions differentes*/
    float timerDownUp;
    float timerUpDown;
    /*detection de 2 differentes positions*/
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
        /*
         * Première position
         * les deux mains sont en position basse
         */
        if (//Mathf.Abs(mainDroite.transform.position.y - mainGauche.transform.position.y) < deltaY &
            mainDroite.transform.position.y < tete.transform.position.y - margeTeteY &
            mainGauche.transform.position.y < tete.transform.position.y - margeTeteY)
        {
            /*
             * Troisième position
            *  On retourne à la première position sachant qu'on a passé par la deuxième position
             */
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

        /*
         * Deuxième position
         * les deux mains sont alignées en position haute et la prémière position est détectée
         */
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
