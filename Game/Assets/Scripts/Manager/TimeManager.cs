using UnityEngine.SceneManagement;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] float activeTime;
    [SerializeField] float increaseTime;

    public float ActiveTime
    {
        get { return activeTime; }
    }

    public float IncreaseTime
    {
        get { return increaseTime; }
    }

    protected override void Awake()
    {
        base.Awake();

        activeTime = 2.5f;
        increaseTime = 2.5f;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    IEnumerator Decrease()
    {
        while (GameManager.Instance.State && activeTime > 0.25f)
        {
            yield return CoroutineCache.WaitForSecond(4.0f);

            activeTime -= 0.25f;

            Debug.Log(activeTime);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(Decrease());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}