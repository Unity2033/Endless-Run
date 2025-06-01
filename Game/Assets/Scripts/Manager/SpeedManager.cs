using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] float speed = 30.0f;
    [SerializeField] float limitSpeed = 60.0f;

    [SerializeField] float initializeSpeed;

    public float Speed { get { return speed; } }

    public float InitializeSpeed { get { return initializeSpeed; } }

    public void Execute()
    {
        StartCoroutine(Increase());
    }

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Execute);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    IEnumerator Increase()
    {     
        while (speed < limitSpeed)
        {
            yield return CoroutineCache.WaitForSecond(0.533f);

            speed = speed + 0.5f;
        }
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        speed = 30f;

        initializeSpeed = speed;
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, Execute);

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}