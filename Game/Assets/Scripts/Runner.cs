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
    public Animator animator;

    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX = 4f;
    [SerializeField] float detectorPositionX = 2.25f;

    [SerializeField] Sound sound = new Sound();

    [SerializeField] LeftDetector leftDetector;
    [SerializeField] RightDetector rightDetector;
    [SerializeField] ParticleSystem particleSystem;

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.timeScale == 0) 
            return;

        Move();

        Status(roadLine);        
    }

    public void Move()
    {
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
            }
        }
    }

    public void OnDeath()
    {
        animator.Play("Die");
        AudioManager.instance.Sound(sound.clips[0]);
    }

    public void Status(RoadLine roadLine)
    {
        switch (roadLine)
        {
            case RoadLine.LEFT:
                transform.position = new Vector3(-positionX, 0, 0);
                leftDetector.transform.position = new Vector3(-positionX + -detectorPositionX, 0, 0);
                rightDetector.transform.position = new Vector3(-positionX + detectorPositionX, 0, 0);
                break;
            case RoadLine.MIDDLE:
                transform.position = new Vector3(0, 0, 0);
                leftDetector.transform.position = new Vector3(-detectorPositionX, 0, 0);
                rightDetector.transform.position = new Vector3(detectorPositionX, 0, 0);
                break;
            case RoadLine.RIGHT:
                transform.position = new Vector3(positionX, 0, 0);
                leftDetector.transform.position = new Vector3(positionX + -detectorPositionX, 0, 0);
                rightDetector.transform.position = new Vector3(positionX + detectorPositionX, 0, 0);
                break;
        }
    }

    public void ScoreEffect()
    {
        particleSystem.Play();
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
