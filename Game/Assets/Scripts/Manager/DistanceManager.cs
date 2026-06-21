using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] float pace = 15f;

    [SerializeField] Text distanceText;

    float distance;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Execute);
        State.Subscribe(Condition.FINISH, Release);
    }

    public void Execute()
    {
        StartCoroutine(Increase());
    }

    void Release()
    {
        DataManager.instance.SetScore(distance);

        StopAllCoroutines();
    }

    private IEnumerator Increase()
    {
        while(true)
        {
            distance += pace * Time.deltaTime;

            distanceText.text = $"{Mathf.FloorToInt(distance)}m";

            yield return null;
        }
    }


    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, Execute);
        State.Unsubscribe(Condition.FINISH, Release);
    }
}
