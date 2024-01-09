using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPanel : MonoBehaviour
{
    [SerializeField] Text currentNumber;

    private void OnEnable()
    {
        Debug.Log(DataManager.instance.QuestScore);
        currentNumber.text = DataManager.instance.QuestScore.ToString() + "m" + " / " + "100000m";
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
