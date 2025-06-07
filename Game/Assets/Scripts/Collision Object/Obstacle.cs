using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IHitable
{
    [SerializeField] Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        State.Subscribe(Condition.FINISH, Release);
    }

    public void CollisionAnimation()
    {
        animator.enabled = true;

        transform.position = new Vector3 (transform.position.x, 0.5f, transform.position.z);

        animator.speed = SpeedManager.instance.Speed / SpeedManager.instance.InitializeSpeed;
    }

    public void Activate()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector3.back * SpeedManager.instance.Speed * Time.deltaTime);
    }

    void Release()
    {
        Destroy(this);
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.FINISH, Release);
    }
}