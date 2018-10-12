using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApartHands : MonoBehaviour {

    public GameObject main_droite;
    public GameObject main_gauche;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Abs(main_droite.transform.position.x - main_gauche.transform.position.x);
        if (x >1){
            Debug.Log("mains ecartees");
        }
	}
}
