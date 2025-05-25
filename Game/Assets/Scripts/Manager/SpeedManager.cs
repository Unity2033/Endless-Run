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

    [SerializeField] Runner runner;

    public float Speed { get { return speed; } }

    public void Execute()
    {
        StartCoroutine(Increase());
    }

    private void OnEnable()
    {
        State.OnExecute += Execute;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    IEnumerator Increase()
    {     
        while (State.Ready && speed < limitSpeed)
        {
            yield return CoroutineCache.WaitForSecond(5.0f);

            speed += 2.5f;

            AnimationSynchronize(runner.GetComponent<Animator>());
        }
    }

    public void AnimationSynchronize(Animator animator)
    {
        animator.speed = speed / initializeSpeed;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        speed = 30f;

        initializeSpeed = speed;

        runner = GameObject.Find("Runner").GetComponent<Runner>();
    }

    private void OnDisable()
    {
        State.OnExecute -= Execute;

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}