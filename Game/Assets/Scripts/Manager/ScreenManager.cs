using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject message;
    [SerializeField] GameObject startButton;

    private void OnEnable()
    {
        State.OnExecute += DisableButton;
        State.OnFinish += GameEnd;

    }

    public void DisableButton()
    {
        AudioManager.instance.ScenerySound("Execute");

        startButton.SetActive(false);
    }

    public void GameEnd()
    {
        message.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        State.OnExecute -= DisableButton;
        State.OnFinish -= GameEnd;
    }
}
