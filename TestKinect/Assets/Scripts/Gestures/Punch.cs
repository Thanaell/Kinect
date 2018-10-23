using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : Gesture
{
    //l'erreur autorisée sur le deplacement Z
    [SerializeField]
    float deltaZ = 0.1f;

    //La distance minimale à détectée entre l'époule et la main pour detecter la main devant l'utilisateur
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

        //Detecte si la main est suffisament devant la personne
        if (Mathf.Abs(mainDroite.transform.position.z - coudeDroit.transform.position.z) > distanceMaxZ/2 &
            Mathf.Abs(coudeDroit.transform.position.z - epauleDroite.transform.position.z) > distanceMaxZ/2 )
        {
            
            isDetected = true;
        }

    }

}
