using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int milliseconds;

    [SerializeField] Text timeText;

    private void OnEnable()
    {
        State.OnExecute += Execute;
    }

    public void Execute()
    {

        StartCoroutine(Measure());
    }

    IEnumerator Measure()
    {
        while (State.Ready)
        {
            time += Time.deltaTime;

            minute = (int)time / 60;
            second = (int)time % 60;
            milliseconds = (int)(time * 100) % 100;

            timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, milliseconds);

            yield return null;
        }
    }

    private void OnDisable()
    {
        State.OnExecute -= Execute;
    }
}