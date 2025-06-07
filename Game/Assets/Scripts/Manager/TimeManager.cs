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

    [SerializeField] float personalRecord;

    [SerializeField] Text timeText;
    [SerializeField] Text latestRunTime;
    [SerializeField] Text fastestRunTime;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Execute);
        State.Subscribe(Condition.FINISH, Release);
        State.Subscribe(Condition.FINISH, RenewalTime);

    }

    public void Execute()
    {
        StartCoroutine(Measure());
    }

    void Release()
    {
        StopAllCoroutines();
    }

    public void RenewalTime()
    {
        if(PlayerPrefs.GetFloat("Time") < time)
        {
            PlayerPrefs.SetFloat("Time", time);

            PlayerPrefs.Save();
        }

        personalRecord = PlayerPrefs.GetFloat("Time");

        latestRunTime.text = "Latest Run   (" + string.Format("{0:D2} : {1:D2} : {2:D2}", (int)time / 60, (int)time % 60, (int)(time * 100) % 100) + ")";
        fastestRunTime.text = "Fastest Run (" + string.Format("{0:D2} : {1:D2} : {2:D2}", (int)personalRecord / 60, (int)personalRecord % 60, (int)(personalRecord * 100) % 100) + ")";
    }

    IEnumerator Measure()
    {
        while (true)
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
        State.Unsubscribe(Condition.START, Execute);
        State.Unsubscribe(Condition.FINISH, Release);
        State.Unsubscribe(Condition.FINISH, RenewalTime);

    }
}