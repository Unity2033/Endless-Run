using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] float pace = 15f;

    [SerializeField] Text distanceText;

    float distance;

    private void Update()
    {
        if (GameManager.instance.State == false) return;
         
        distance += pace * Time.deltaTime;

        distanceText.text = $"{Mathf.FloorToInt(distance)}m";
    }

    public void Initialize()
    {
        DataManager.instance.Save(distance);

        distance = 0;

        distanceText.text = $"{Mathf.FloorToInt(distance)}m";
    }
}


