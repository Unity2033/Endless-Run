using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] float speed = 30.0f;
    [SerializeField] float limitSpeed = 60.0f;

    [SerializeField] float initializeSpeed;

    public float Speed { get { return speed; } }

    public float InitializeSpeed { get { return initializeSpeed; } }

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Execute);
        State.Subscribe(Condition.FINISH, Release);
    }

    public void Lanuch()
    {
        State.Publish(Condition.START);
    }

    public void Execute()
    {
        StartCoroutine(Increase());
    }

    IEnumerator Increase()
    {     
        while (speed < limitSpeed)
        {
            yield return CoroutineCache.WaitForSecond(0.533f);
            
            speed = speed + 0.5f;
        }
    }

    void Release()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, Execute);
        State.Unsubscribe(Condition.FINISH, Release);
    }
}