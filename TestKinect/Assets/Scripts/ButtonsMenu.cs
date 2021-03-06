﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//classe regroupant les méthodes appelées lorsqu'on clique sur un bouton du menu
public class ButtonsMenu : MonoBehaviour {

    [SerializeField]
    private Text explanationsText;
	public void onExitButton()
    {
        Application.Quit();
    }

    public void onChangeSceneButton()
    {
        SceneManager.LoadScene(1);
    }

    public void onSwipingRightButton()
    {
        explanationsText.text = "Tendez le bras droit à l'horizontale vers la droite, puis ramenez le.";
    }

    public void onSwipingLeftButton()
    {
        explanationsText.text = "Tendez le bras droit à l'horizontale vers la gauche, puis ramenez le.";
    }

    public void onSwipingUpButton()
    {
        explanationsText.text = "Tendez les deux bras vers le haut, puis redescendez-les.";
    }

    public void onPunchingButton()
    {
        explanationsText.text = "Donnez un coup de poing vers la Kinect, en tendant bien le bras devant vous.";
    }

    public void onRunningButton()
    {
        explanationsText.text = "Les coudes au corps : mettez la main gauche sur l'épaule gauche, et faites un angle de 90° avec votre bras droit. Puis inversez les positions de vos bras 4 à 6 fois.";
    }

    public void onClosingButton()
    {
        explanationsText.text = "Mettez vos deux mains à la hauteur de vos épaules, puis écartez-les. Ensuite, refermez-les devant vous.";
    }
}
