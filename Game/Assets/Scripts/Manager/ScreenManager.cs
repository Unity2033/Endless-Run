using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject timePanel;
    [SerializeField] GameObject resultPanel;
    [SerializeField] GameObject startButton;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, ExecuteInterface);
        State.Subscribe(Condition.FINISH, FinishInterface);
    }

    public void ExecuteInterface()
    {
        timePanel.SetActive(true);
        startButton.SetActive(false);

        AudioManager.instance.ScenerySound("Execute");
    }

    public void FinishInterface()
    {
        timePanel.SetActive(false);
        resultPanel.SetActive(true);
    }

    public void OnDisable()
    {
        State.Unsubscribe(Condition.START, ExecuteInterface);
        State.Unsubscribe(Condition.FINISH, FinishInterface);
    }
}
