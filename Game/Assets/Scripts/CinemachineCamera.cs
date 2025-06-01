using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineCamera : MonoBehaviour
{
    [SerializeField] Runner runner;
     
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Follow);

        State.Subscribe(Condition.FINISH, Observe);
    }

    public void Follow()
    {
        cinemachineVirtualCamera.Follow = runner.transform;
    }

    public void Observe()
    {
        cinemachineVirtualCamera.LookAt = runner.transform;
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, Follow);

        State.Unsubscribe(Condition.FINISH, Observe);
    }
}
