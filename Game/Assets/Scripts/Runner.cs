using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : State
{
    [SerializeField] Animator animator;

    [SerializeField] RoadLine roadLine;
    [SerializeField] RoadLine previousRoadLine;

    [SerializeField] Rigidbody rigidBody;

    [SerializeField] float speed = 25.0f;
    [SerializeField] float positionX = 4f;

    private void OnEnable()
    {
        base.OnEnable();

        InputManager.instance.keyAction += OnKeyUpdate;      
    }


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        roadLine = RoadLine.MIDDLE;
        previousRoadLine = RoadLine.MIDDLE;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnKeyUpdate()
    {
        if (state == false) return;
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != RoadLine.LEFT)
            {
                previousRoadLine = roadLine;

                roadLine--;

                animator.Play("Left Avoid");
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RoadLine.RIGHT)
            {
                previousRoadLine = roadLine;

                roadLine++;

                animator.Play("Right Avoid");
            }
        }
    }

    public void RevertPosition()
    {
        roadLine = previousRoadLine;
    }

    private void Move()
    {
        if (state == false) return;

        rigidBody.position = Vector3.Lerp
        (
            rigidBody.position, 
            new Vector3(positionX * (int)roadLine, 0, 0), 
            speed * Time.deltaTime
        );
    }

    public void UpdateAnimator()
    {
        animator.speed = SpeedManager.Speed / 20;
    }

    public void Die()
    {
        animator.Play("Die");

        state = false;
    }

    private void OnDisable()
    {
        base.OnDisable();

        InputManager.instance.keyAction -= OnKeyUpdate;
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionObject collisionObject = other.GetComponent<CollisionObject>();

        if(collisionObject != null)
        {
            collisionObject.Activate(this);
        }
    }
}
