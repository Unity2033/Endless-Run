using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBox : CollisionObject
{
    [SerializeField] float initVelocity;

    public void Start()
    {
        initVelocity = GameManager.instance.speed;
    }

    public override void Activate(Runner runner)
    {
        runner.animator.speed = GameManager.instance.speed / initVelocity;

        RoadManager.roadCallBack();
        GameManager.instance.IncreaseVelocity();
    }
}
