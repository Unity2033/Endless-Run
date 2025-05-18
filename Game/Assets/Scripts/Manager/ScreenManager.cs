using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject resultScreen;

    private void OnEnable()
    {
        State.OnExecute += DisableButton;

        State.OnFinish += EnableScreen;
    }

    public void DisableButton()
    {
        startButton.SetActive(false);
    }

    public void EnableScreen()
    {
        resultScreen.SetActive(true);
    }

    private void OnDisable()
    {
        State.OnExecute -= DisableButton;

        State.OnFinish -= EnableScreen;

    }

}
