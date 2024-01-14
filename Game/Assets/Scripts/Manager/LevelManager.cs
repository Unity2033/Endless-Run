using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelManager : MonoBehaviour
{
    public static int level = 0;
    private float decreaseValue = 0.05f;

    public static float maximumSpawn = 2.5f;
    public static float minimumSpawn = 2.25f;

    [SerializeField] UnityEvent unityEvent;
    [SerializeField] int increaseScore = 10;

    private void Awake()
    {
        level = 0;
        maximumSpawn = 2.5f;
        minimumSpawn = 2.25f;
    }

    public void Start()
    {
        StartCoroutine(IncreaseScore());
    }

    public void ControlLevel()
    {
        if (level++ < 40)
        {
            maximumSpawn -= decreaseValue;
            minimumSpawn -= decreaseValue;
        }

        if(level == 40)
        {
            level = 40;
        }
    }

    IEnumerator IncreaseScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            if(GameManager.instance.state == false)
            {
                yield break;
            }

            DataManager.instance.Score += increaseScore;
            DataManager.instance.QuestScore += increaseScore;

            unityEvent.Invoke();
        }
    }
}
