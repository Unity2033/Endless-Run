using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] float sequence = 1f;
    [SerializeField] float limitVelocity = 50;

    [SerializeField] public bool state = true; 
    [SerializeField] public float speed = 20f;

    public void Init()
    {
        speed = 20;
        state = true;
        DataManager.instance.Score = 0;
    }

    public void GameOver()
    {
        state = false;

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
