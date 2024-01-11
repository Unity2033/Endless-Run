using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPanel : MonoBehaviour
{
    [SerializeField] Text currentNumber;

    private void OnEnable()
    {
        if (DataManager.instance.QuestScore < 100000)
        {
            currentNumber.text = DataManager.instance.QuestScore.ToString() + "m" + " / " + "100000m";
        }
        else
        {
            currentNumber.color = Color.green;
            currentNumber.text = "Completed";
        }
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
