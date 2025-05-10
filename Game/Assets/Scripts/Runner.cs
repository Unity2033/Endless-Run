using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Keyboard();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Keyboard()
    {
        if (GameManager.instance.State == false) return;

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
        if (GameManager.instance.State == false) return;

        rigidBody.position = Vector3.Lerp
        (
            rigidBody.position, 
            new Vector3(positionX * (int)roadLine, 0, 0),
            SpeedManager.instance.Speed * Time.deltaTime
        );
    }

    public void Synchronize()
    {
        animator.speed = SpeedManager.instance.Speed / SpeedManager.instance.InitializeSpeed;
    }

    public void Die()
    {
        animator.Play("Die");

        GameManager.instance.Finish();

        cinemachineVirtualCamera.LookAt = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        Obstacle collisionObject = other.GetComponent<Obstacle>();

        if(collisionObject != null)
        {
            Die();
        }
    }
}
