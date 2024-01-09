using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreBox : CollisionObject
{
    [SerializeField] UnityEvent scoreEvent;

    [SerializeField] Vector3 InitDirection;
    [SerializeField] int increaseScore = 10;

    private void Start()
    {
        InitDirection = transform.position;
    }

    private void Update()
    {
        if (GameManager.instance.state == false) return;

        transform.Translate(Vector3.back * GameManager.instance.speed * Time.deltaTime);
    }

    public override void Activate(Runner runner)
    {
        DataManager.instance.Score += increaseScore;
        DataManager.instance.QuestScore += increaseScore;

        if (DataManager.instance.Score % 250 == 0)
        {
            runner.ScoreEffect(); 
            GameManager.instance.difficulty.ControlLevel();
        }

        scoreEvent.Invoke();

        transform.position = InitDirection;
    }
}
