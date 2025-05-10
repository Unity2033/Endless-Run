using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private bool state;

    [SerializeField] UnityEvent resume;
    [SerializeField] UnityEvent finish;
    [SerializeField] UnityEvent execute;

    public bool State
    {
        get { return state; }
    }

    public void Execute()
    {
        state = true;

        execute?.Invoke();
    }

    public void Finish()
    {
        state = false;

        finish?.Invoke();
    }

    public void Resume()
    {
        StartCoroutine(SceneryManager.instance.AsyncLoad(SceneManager.GetActiveScene().buildIndex));
    }
}
