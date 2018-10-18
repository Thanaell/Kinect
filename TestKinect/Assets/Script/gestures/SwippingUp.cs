using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwippingUp : Gesture
{
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
    float deltaY = 0.01f;

    public GameObject tete;
    public GameObject mainDroite;
    public GameObject mainGauche;

    int compteurFrame;
    int compteurUp;
    int compteurDown;
    int compteurUpDown;
    float ypositionPreviousRight;
    float ypositionCurrentRight;
    float ypositionPreviousLeft;
    float ypositionCurrentLeft;

    float[] positionsLeft;
    float[] positionsRight;



    public override void localStart()
    {
        // transform.position += new Vector3(1, 0, 0);

        compteurFrame = 0;
        compteurUp = 0;
        compteurDown = 0;
        compteurUpDown = 0;

        ypositionPreviousRight = mainDroite.transform.position.y - tete.transform.position.y;
        ypositionCurrentRight = ypositionPreviousRight;
        ypositionPreviousLeft = mainGauche.transform.position.y - tete.transform.position.y;
        ypositionCurrentLeft = ypositionPreviousRight;

        positionsLeft = new float[FrameNumber];
        positionsRight = new float[FrameNumber];
    }

    public override void detect()
    {

        if (compteurDown >= PointNumberSwippe)
        {
            compteurDown = 0;
            if (compteurUpDown > 0 )// & mainDroite.transform.position.y < tete.transform.position.y & mainGauche.transform.position.y < tete.transform.position.y)
            {
                isDetected = true;
                compteurUpDown = 0;
            }
        }
        if (compteurUp >= PointNumberSwippe)
        {
            compteurUp = 0;
            if (mainDroite.transform.position.y > tete.transform.position.y & mainGauche.transform.position.y > tete.transform.position.y)
            {
                compteurUpDown = PointNumberAction;
            }
        }




        // échantillon toutes les 5 frames
        if (compteurFrame == FrameNumber)
        {

            compteurFrame = 0;
            ypositionPreviousRight = ypositionCurrentRight;
            ypositionPreviousLeft = ypositionCurrentLeft;

            //on calcule la moyenne des FrameNumber points
            ypositionCurrentRight = 0;
            ypositionCurrentLeft = 0;
            for (int j = 0; j < FrameNumber; j++)
            {
                ypositionCurrentRight += positionsRight[j];
                ypositionCurrentLeft += positionsLeft[j];
            }
            ypositionCurrentRight = ypositionCurrentRight / FrameNumber;
            ypositionCurrentLeft = ypositionCurrentLeft / FrameNumber;

            if (ypositionCurrentRight > ypositionPreviousRight & ypositionCurrentLeft > ypositionPreviousLeft)
            {
                compteurUp++;
            }
            else if (ypositionCurrentRight < ypositionPreviousRight || ypositionCurrentLeft < ypositionPreviousLeft)
            {
                compteurUp = 0;
            }
            if (ypositionCurrentRight < ypositionPreviousRight & ypositionCurrentLeft < ypositionPreviousLeft)
            {
                compteurDown++;
            }
            else if (ypositionCurrentRight > ypositionPreviousRight || ypositionCurrentLeft > ypositionPreviousLeft)
            {
                compteurDown = 0;
            }
            if (compteurUpDown > 0)
            {
                compteurUpDown--;
            }
        }
        positionsLeft[compteurFrame] = mainGauche.transform.position.y - tete.transform.position.y;
        positionsRight[compteurFrame] = mainDroite.transform.position.y - tete.transform.position.y;
        compteurFrame++;

    }

}
