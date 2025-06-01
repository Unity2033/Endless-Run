using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] RoadLine roadLine;

    [SerializeField] Rigidbody rigidBody;

    [SerializeField] float positionX = 4f;

    private void OnEnable()
    {
        State.Subscribe(Condition.FINISH, Die);
        State.Subscribe(Condition.FINISH, Release);

        State.Subscribe(Condition.START, InputSystem);
        State.Subscribe(Condition.START, StateTransition);
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    IEnumerator Coroutine()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (roadLine != RoadLine.LEFT)
                {
                    roadLine--;

                    animator.Play("Left Avoid");
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (roadLine != RoadLine.RIGHT)
                {
                    roadLine++;

                    animator.Play("Right Avoid");
                }
            }

            yield return null;
        }
    }

    public void InputSystem()
    {
        StartCoroutine(Coroutine());
    }

    public void Synchronize()
    {
        animator.speed = SpeedManager.instance.Speed / SpeedManager.instance.InitializeSpeed;
    }

    private void FixedUpdate()
    {
        rigidBody.position = Vector3.Lerp
        (
            rigidBody.position,
            new Vector3(positionX * (int)roadLine, 0, 0),
            SpeedManager.instance.Speed * Time.deltaTime
        );
    }

    void Release()
    {
        StopAllCoroutines();
    }

    public void StateTransition()
    {
        animator.SetTrigger("Start");
    }

    public void Die()
    {
        animator.Play("Die");

        AudioManager.instance.Listen("Conflict");
    }

    private void OnTriggerEnter(Collider other)
    {
        Obstacle collisionObject = other.GetComponent<Obstacle>();

        if(collisionObject != null)
        {
            State.Publish(Condition.FINISH);
        }
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.FINISH, Die);
        State.Unsubscribe(Condition.FINISH, Release);

        State.Unsubscribe(Condition.START, InputSystem);
        State.Unsubscribe(Condition.START, StateTransition);
    }
}
