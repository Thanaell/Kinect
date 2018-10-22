using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KeyboardInputHandler : MonoBehaviour {
	void Update () {
		if (Input.GetKey(KeyCode.Escape)) //retourne au menu sur appui de Escape
        {
            SceneManager.LoadScene(0);
        }
	}
}
