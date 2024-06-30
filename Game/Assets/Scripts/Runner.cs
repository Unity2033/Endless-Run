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
    [SerializeField] Animator animator;

    [SerializeField] RoadLine roadLine;
    [SerializeField] RoadLine previousRoadLine;

    [SerializeField] float speed = 25.0f;
    [SerializeField] float positionX = 4f;

    [SerializeField] bool state = true;

    private void OnEnable()
    {
        InputManager.instance.keyAction += OnKeyUpdate;
        
        EventManager.Susbscribe(EventType.START, Execute);
        EventManager.Susbscribe(EventType.STOP , Stop);
    }

    private void Execute()
    {
        state = true;
    }

    private void Stop()
    {
        animator.Play("Die");

        ResourceManager.instance.Instance("Game Over Panel", GameObject.Find("UI Canvas").transform);

        state = false;
    }

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
        previousRoadLine = RoadLine.MIDDLE;
        animator = GetComponent<Animator>();
    }

    private void Update()
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

        transform.position = Vector3.Lerp
        (
            transform.position, 
            new Vector3(positionX * (int)roadLine, 0, 0), 
            speed * Time.deltaTime
        );
    }

    private void OnDisable()
    {
        InputManager.instance.keyAction -= OnKeyUpdate;

        EventManager.Unsubscribe(EventType.START, Execute);
        EventManager.Unsubscribe(EventType.STOP , Stop);
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
