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

public class Runner : MonoBehaviour
{
    public Animator animator;

    [SerializeField] RoadLine roadLine;
    [SerializeField] float speed = 25.0f;
    [SerializeField] float positionX = 4f;

    [SerializeField] LeftDetector leftDetector;
    [SerializeField] RightDetector rightDetector;

    private void OnEnable()
    {
        InputManager.instance.keyAction += Move;
    }

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Status(roadLine);
    }

    public void Move()
    {
        if (GameManager.instance.state == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (leftDetector.Detector)
            {
                return;
            }

            if (roadLine > RoadLine.LEFT)
            {
                roadLine--;
                animator.Play("Left Avoid");
            }
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rightDetector.Detector)
            {
                return;
            }

            if (roadLine < RoadLine.RIGHT)
            {
                roadLine++;
                animator.Play("Right Avoid");
            }
        }
    }

    public void Status(RoadLine roadLine)
    {
        switch (roadLine)
        {
            case RoadLine.LEFT : SmoothMovement(-positionX);
                break;
            case RoadLine.MIDDLE : SmoothMovement(0);
                break;
            case RoadLine.RIGHT : SmoothMovement(positionX);
                break;
        }
    }

    private void SmoothMovement(float x)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(x, 0, 0), speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        InputManager.instance.keyAction -= Move;
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
