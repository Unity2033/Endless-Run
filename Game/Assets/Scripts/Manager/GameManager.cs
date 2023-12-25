using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public float speed = 20f;
    [SerializeField] public float sequence = 1f;
    [SerializeField] public float limitVelocity = 50;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;        
    }

    public void Resume()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IncreaseVelocity()
    {
        if (speed < limitVelocity)
        {
            speed += sequence;
        }
    }
}
