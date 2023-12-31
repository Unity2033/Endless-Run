using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public float speed = 20f;
    [SerializeField] public float sequence = 1f;
    [SerializeField] public float limitVelocity = 50;

    public void Init()
    {
        speed = 20;
        Time.timeScale = 1.0f;
        DataManager.instance.Score = 0;
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;

        DataManager.instance.SetRankScore(DataManager.instance.Score);

        Instantiate(Resources.Load<GameObject>("Game Over Panel"), GameObject.Find("UI Canvas").transform);
    }

    public void IncreaseVelocity()
    {
        if (speed < limitVelocity)
        {
            speed += sequence;
        }
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Init();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
