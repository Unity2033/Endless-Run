using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX = 4f;
    [SerializeField] float jumpPower = 20f;

    [SerializeField] ObjectSound objectSound = new ObjectSound();

    [SerializeField] UnityEvent playerEvent;

    private Animator animator ;

    void Start()
    {
        roadLine = RoadLine.MIDDLE;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();

        Status(roadLine);        
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.timeScale != 0 )
        {
            AudioManager.instance.Sound(objectSound.clips[0]);
            if(roadLine == RoadLine.LEFT)
            {
                roadLine = RoadLine.LEFT;
            }
            else { roadLine--; }
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Time.timeScale != 0 )
        {
            AudioManager.instance.Sound(objectSound.clips[0]);
            if (roadLine == RoadLine.RIGHT)
            {
                roadLine = RoadLine.RIGHT;
            }
            else { roadLine++; }
        }
    }

    public void Status(RoadLine roadLine)
    {
        switch (roadLine)
        {
            case RoadLine.LEFT:
                transform.position = new Vector3(-positionX, 0, 0);
                break;
            case RoadLine.MIDDLE:
                transform.position = new Vector3(0, 0, 0);
                break;
            case RoadLine.RIGHT:
                transform.position = new Vector3(positionX, 0, 0);                
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();

        if(item != null)
        {            
            item.Use();
            other.GetComponentInChildren<MeshRenderer>().enabled = false;
        }

        if(other.CompareTag("Obstacle"))
        {
            Death();
        }
    }


    private void Death()
    {
        playerEvent.Invoke();
        animator.Play("Die");
    }

    public void OnGameOverUI()
    {
        GameManager.instance.GameOverPanel();
    }
}