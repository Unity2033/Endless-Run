using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IHitable
{
    private void OnEnable()
    {
        State.Subscribe(Condition.FINISH, Release);
    }

    public void Activate()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector3.back * SpeedManager.instance.Speed * Time.deltaTime);
    }

    void Release()
    {
        Destroy(this);
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.FINISH, Release);
    }
}