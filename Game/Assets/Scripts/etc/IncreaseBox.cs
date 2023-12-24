using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBox : MonoBehaviour, IItem
{
    [SerializeField] float initVelocity;

    public void Start()
    {
        initVelocity = GameManager.instance.speed;
    }

    public void Use(Runner runner)
    {
        runner.animator.speed = GameManager.instance.speed / initVelocity;

        RoadManager.roadCallBack();
        GameManager.instance.IncreaseVelocity();
    }
}
