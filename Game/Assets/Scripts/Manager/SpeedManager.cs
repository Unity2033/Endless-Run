using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] float speed = 30.0f;
    [SerializeField] float limitSpeed = 60.0f;

    [SerializeField] float initializeSpeed;

    [SerializeField] Runner runner;

    public float Speed { get { return speed; } }

    public float InitializeSpeed { get { return initializeSpeed; } }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    IEnumerator Increase()
    {
        while(GameManager.instance.State && speed < limitSpeed)
        {
            yield return CoroutineCache.WaitForSecond(5.0f);

            speed += 2.5f;

            runner.Synchronize();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        speed = 30f;

        initializeSpeed = speed;

        if (scene.buildIndex == 1)
        {
            runner = GameObject.Find("Runner").GetComponent<Runner>();

            StartCoroutine(Increase());
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}