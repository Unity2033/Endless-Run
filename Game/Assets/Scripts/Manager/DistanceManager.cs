using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] float pace = 15f;

    [SerializeField] Text distanceText;

    float distance;

    public void Execute()
    {
        StartCoroutine(Increase());
    }

    private IEnumerator Increase()
    {
        while(GameManager.instance.State)
        {
            distance += pace * Time.deltaTime;

            distanceText.text = $"{Mathf.FloorToInt(distance)}m";

            yield return null;
        }

        DataManager.instance.Save(distance);
    }
}
