using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

    [SerializeField] AudioClip audioClip;

    [SerializeField] UnityEvent callback;

    [SerializeField] float positionX = 4f;

    private void OnEnable()
    {
        State.OnFinish += Die;

        State.OnExecute += Execute;
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (State.Ready == false) return;

        Keyboard();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Keyboard()
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
    }

    private void Move()
    {
        rigidBody.position = Vector3.Lerp
        (
            rigidBody.position, 
            new Vector3(positionX * (int)roadLine, 0, 0),
            SpeedManager.instance.Speed * Time.deltaTime
        );
    }

    public void Execute()
    {
        animator.SetTrigger("Start");
    }

    public void Die()
    {
        animator.Play("Die");

        AudioManager.instance.Listen(audioClip);
    }

    public void Resume()
    {
        StartCoroutine(SceneryManager.instance.AsyncLoad(SceneManager.GetActiveScene().buildIndex));
    }

    private void OnTriggerEnter(Collider other)
    {
        Obstacle collisionObject = other.GetComponent<Obstacle>();

        if(collisionObject != null)
        {
            callback.Invoke();
        }
    }

    private void OnDisable()
    {
        State.OnFinish -= Die;

        State.OnExecute -= Execute;
    }
}
