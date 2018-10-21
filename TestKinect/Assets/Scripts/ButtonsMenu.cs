using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        explanationsText.text = "Donnez un coup de poing vers la Kinect, en alignant main, coude et épaule.";
    }

    public void onRunningButton()
    {
        explanationsText.text = "Les coudes au corps : mettez la main gauche sur l'épaule gauche, et faites un angle de 90° avec votre bras droit. Puis inversez les positions de vos bras 3 fois.";
    }

    public void onClosingButton()
    {
        explanationsText.text = "Les coudes au corps, écartez vos mains au maximum. Puis refermez-les devant vous.";
    }
}
