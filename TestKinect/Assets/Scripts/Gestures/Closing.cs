using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closing : Gesture{

    /*l'erreur autorisée en X*/
    [SerializeField]
    float deltaX = 0.05f;

    /*distance minimale entre 2 mains écartées*/
    [SerializeField]
    float disctanceMaxX= 0.8f;

    /*l'erreur autorisée en Y*/
    [SerializeField]
    float deltaY = 0.1f;

    
    public GameObject mainDroite;
    public GameObject mainGauche;
    public GameObject tete;
    
    bool FirstPosition; //renvoie True si la Kinect a detecté la première position
    float timerOpenClose; //le temps maximal pour passer de la position 1 à la position 2

    public override void localStart()
    {
        FirstPosition = false;
        timerOpenClose = 0;
    }

    public override void detect()
    {
        /*
         * Première position:
         * les deux mains sont écartées et sont alignées avec la tête
         */
        if (mainDroite.transform.position.x-mainGauche.transform.position.x > disctanceMaxX &
            Mathf.Abs(tete.transform.position.y-mainGauche.transform.position.y)<deltaY &
            Mathf.Abs(tete.transform.position.y - mainDroite.transform.position.y) < deltaY)
        {

            FirstPosition = true;
            timerOpenClose = gestureTime ; 

        }
        if (timerOpenClose > 0)
        {
            timerOpenClose-=Time.deltaTime; 
        }
        else
        {
            timerOpenClose = 0;
            FirstPosition = false;
        }

        /*
         * Deuxième position:
         * les deux mains sont quasiment au même endroit et sont alignées avec la tête
         * et la position une a été détectée
         */
        if (Mathf.Abs(mainDroite.transform.position.x-mainGauche.transform.position.x)<deltaX &
           Mathf.Abs(tete.transform.position.y - mainGauche.transform.position.y) < deltaY &
            Mathf.Abs(tete.transform.position.y - mainDroite.transform.position.y) < deltaY &
           FirstPosition)
        {
            FirstPosition = false;
            isDetected = true;
            timerOpenClose = 0;

        }

    }
}
