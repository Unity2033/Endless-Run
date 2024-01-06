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
    [SerializeField] float detectorPositionX = 2.25f;

    [SerializeField] Sound sound = new Sound();

    [SerializeField] LeftDetector leftDetector;
    [SerializeField] RightDetector rightDetector;
    [SerializeField] ParticleSystem particleSystem;

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

            if (roadLine == RoadLine.LEFT)
            {
                roadLine = RoadLine.LEFT;
            }
            else 
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

            if (roadLine == RoadLine.RIGHT)
            {
                roadLine = RoadLine.RIGHT;
            }
            else 
            {
                roadLine++;
                animator.Play("Right Avoid");
            }
        }
    }

    public void OnDeath()
    {
        animator.SetTrigger("Death");
        AudioManager.instance.Sound(sound.clips[0]);
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
        leftDetector.transform.position =  new Vector3(x + -detectorPositionX, 0, 0);
        rightDetector.transform.position =  new Vector3(x + detectorPositionX, 0, 0);
    }

    public void ScoreEffect()
    {
        particleSystem.Play();
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
