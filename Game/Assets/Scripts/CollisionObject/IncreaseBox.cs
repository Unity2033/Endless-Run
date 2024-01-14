using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IncreaseBox : CollisionObject
{
    [SerializeField] float initVelocity;
    [SerializeField] UnityEvent callback;

    public void Start()
    {
        initVelocity = GameManager.instance.speed;
    }

    public override void Activate(Runner runner)
    {
        runner.animator.speed = GameManager.instance.speed / initVelocity;

        callback.Invoke();

        GameManager.instance.IncreaseSequence();
    }
}
