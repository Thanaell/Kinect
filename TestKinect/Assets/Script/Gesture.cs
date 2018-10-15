using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TypeEvent : UnityEvent<System.Type> { }
public abstract class Gesture : MonoBehaviour {
    [SerializeField]
    private GestureHandler handler;
    protected bool isDetected;
    public abstract void detect();
    public TypeEvent myEvent=new TypeEvent();
    // Use this for initialization
    public abstract void localStart();
	void Start () {
        isDetected = false;
        myEvent.AddListener(handler.GestureDisplay);
        localStart();
    }
	
	// Update is called once per frame
	void Update () {
        detect();
        if (isDetected)
        {
            myEvent.Invoke(this.GetType());
        }
	}
}
