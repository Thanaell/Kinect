﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour {

	public void onExitButton()
    {
        Application.Quit();
    }

    public void onChangeSceneButton()
    {
        SceneManager.LoadScene(1);
    }
}
