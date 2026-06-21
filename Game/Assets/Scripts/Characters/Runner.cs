using System.Collections;
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

    [SerializeField] float factor = 10.0f;

    [SerializeField] RoadLine previousLine;

    private void OnEnable()
    {
        State.Subscribe(Condition.FINISH, Die);
        State.Subscribe(Condition.FINISH, Release);

        State.Subscribe(Condition.START, InputSystem);
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
                    previousLine = roadLine;

                    roadLine--;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (roadLine != RoadLine.RIGHT)
                {
                    previousLine = roadLine;

                    roadLine++;
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
        animator.speed = GameManager.instance.Speed / GameManager.instance.InitializeSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 nextPosition = new Vector3(positionX * (int)roadLine, rigidBody.position.y, rigidBody.position.z);

        rigidBody.linearVelocity = (nextPosition - rigidBody.position) * factor;
    }

    void Release()
    {
        StopAllCoroutines();
    }

    public void Die()
    {
        animator.Play("Die");

        AudioManager.instance.Listen("Conflict");
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;

        float dot = Vector3.Dot(transform.forward, -normal);

        Obstacle collisionObject = collision.gameObject.GetComponent<Obstacle>();

        if (collisionObject != null)
        {
            if (dot > 0.7f)
            {
                State.Publish(Condition.FINISH);
            }
            else
            {
                roadLine = previousLine;

                AudioManager.instance.Listen("Collision");
            }
        }
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.FINISH, Die);
        State.Unsubscribe(Condition.FINISH, Release);

        State.Unsubscribe(Condition.START, InputSystem);
    }
}