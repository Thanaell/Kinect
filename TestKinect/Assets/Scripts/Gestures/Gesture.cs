using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TypeEvent : UnityEvent<System.Type> { }//classe d'évènements acceptant un argument de type Type

//classe abstraite mère de tous les gestes
public abstract class Gesture : MonoBehaviour {
    [SerializeField]
    private GestureHandler handler;
    protected bool isDetected;
    [SerializeField]
    protected float gestureTime=3; // temps alloué à la détection du geste (temps dans lequel il faut l'accomplir)
    public abstract void detect(); // doit changer le booléen isDetected à true quand un geste est détecté
    public TypeEvent myEvent=new TypeEvent();
    public abstract void localStart();

	void Start () {
        isDetected = false;
        myEvent.AddListener(handler.GestureDisplay); //ajout de la méthode qui recevra les évènements
        localStart();
    }
	
	void Update () {
        detect();
        if (isDetected )
        {
            myEvent.Invoke(this.GetType()); //envoie un évènement quand un geste est détecté, avec en argument le type de geste
            isDetected = false;
        }
	}
}
