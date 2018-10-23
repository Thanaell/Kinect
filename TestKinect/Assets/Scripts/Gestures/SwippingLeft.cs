using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwippingLeft : Gesture
{
    //l'erreur autorisée sur x
    [SerializeField]
    float deltaX = 0.1f;

    //l'erreur autorisée sur y
    [SerializeField]
    float deltaY = 0.1f;

    //distance entre l'époule et la main lorsqu'en est en deuxième position
    [SerializeField]
    float distanceMaxX = 0.4f;


    public GameObject epauleDroite;
    public GameObject coudeDroit;
    public GameObject mainDroite;

    bool FirstPosition;
    float timerLeftRight;
    bool SecondPosition;
    float timerRightLeft;

    public override void localStart()
    {
        FirstPosition = false;
        timerLeftRight = 0;
        SecondPosition = false;
        timerRightLeft = 0;
    }

    public override void detect()
    {
        /*
         * Première position
         * la main droite près de l'épaule
         */
        if (Mathf.Abs(epauleDroite.transform.position.x - mainDroite.transform.position.x) < deltaX)
        {
            /*
             * Troisième position
             * On revient à la position une sachant qu'on a executé la deuxième position
             */
            if (SecondPosition)
            {
                isDetected = true;
                SecondPosition = false;
                timerRightLeft = 0;
            }
            FirstPosition = true;
            timerLeftRight = gestureTime;

        }
        if (timerLeftRight > 0)
        {
            timerLeftRight-=Time.deltaTime;
        }
        else
        {
            timerLeftRight = 0;
            FirstPosition = false;
        }

        /*
         * Deuxième position
         * la main droite, l'epaule droite et le coude droit sont alignées, la première position a été détectée
         * et la main est  au moins à la distance maximale de l'épaule (main plus à gauche)
         */
        if (Mathf.Abs(coudeDroit.transform.position.y - mainDroite.transform.position.y) < deltaY &
            Mathf.Abs(mainDroite.transform.position.y - coudeDroit.transform.position.y) < deltaY &
            epauleDroite.transform.position.x - mainDroite.transform.position.x > distanceMaxX &
            FirstPosition)
        {
            FirstPosition = false;
            timerLeftRight = 0;
            timerRightLeft = gestureTime;
            SecondPosition = true;
        }
        if (timerRightLeft > 0)
        {
            timerRightLeft-=Time.deltaTime;
        }
        else
        {
            timerRightLeft = 0;
            SecondPosition = false;
        }

    }
}
