using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] bool state;

    [SerializeField] float speed = 30.0f;

    [SerializeField] float initializeSpeed;

    public float Speed { get { return speed; } }

    public float InitializeSpeed { get { return initializeSpeed; } }

    public bool State { get { return state; } set { state = value; } }

    [SerializeField] UnityEvent callback;

    private void Start()
    {
        initializeSpeed = speed;
    }

    public void Resume()
    {
        speed = initializeSpeed;

        if (callback != null)
        {
            callback.Invoke();
        }
    }

    public void Increase()
    {
        speed += 0.5f / (1 + speed * 0.02f);
    }
}