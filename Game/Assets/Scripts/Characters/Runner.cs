using UnityEngine;
using UnityEngine.SceneManagement;

public class Runner : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] Line roadLine;

    [SerializeField] Line previousLine;

    [SerializeField] Rigidbody rigidBody;

    [SerializeField] float positionX = 4f;

    [SerializeField] float factor = 10.0f;

    [SerializeField] ScreenManager screenManager;

    void Start()
    {  
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.instance.State == false) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != Line.LEFT)
            {
                previousLine = roadLine;

                roadLine--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != Line.RIGHT)
            {
                previousLine = roadLine;

                roadLine++;
            }
        }
    }

    public void Synchronize()
    {
        GameManager.instance.Increase();

        animator.speed = GameManager.instance.Speed / GameManager.instance.InitializeSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 nextPosition = new Vector3(positionX * (int)roadLine, rigidBody.position.y, rigidBody.position.z);

        rigidBody.linearVelocity = (nextPosition - rigidBody.position) * factor;
    }

    public void Die()
    {
        animator.Play("Die");

        animator.speed = 1.0f;

        screenManager.FadeIn();

        GameManager.instance.State = false;

        AudioManager.instance.Listen("Conflict");
    }

    public void Resume()
    {
        GameManager.instance.Resume();
    }

    public void Reset()
    {
        roadLine = Line.MIDDLE;
        previousLine = Line.MIDDLE;

        animator.Play("Idle");
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
                Die();
            }
            else
            {
                roadLine = previousLine;

                AudioManager.instance.Listen("Collision");
            }
        }
    }
}