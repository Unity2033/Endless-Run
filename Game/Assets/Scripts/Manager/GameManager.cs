using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Difficulty
{
    private float decreaseValue = 0.25f;
    private int increaseSpeedValue = 5;

    private float maximumSpawn = 2.5f;
    private float minimumSpawn = 2.25f;

    private int maximumEnableSpeed = 5;
    private int minimumEnableSpeed = 0;

    public void ControlLevel()
    {
        if (maximumSpawn > 0.5f && minimumSpawn > 0.25f)
        {
            maximumSpawn -= decreaseValue;
            minimumSpawn -= decreaseValue;
        }

        if (maximumEnableSpeed < 40 && minimumEnableSpeed < 35)
        {
            maximumEnableSpeed += increaseSpeedValue;
            minimumEnableSpeed += increaseSpeedValue;
        }
    }

    public float MaximumSpawn
    {
        set { maximumSpawn = value; }
        get { return maximumSpawn; }
    }

    public float MinimumSpawn
    {
        set { minimumSpawn = value; }
        get { return minimumSpawn; }
    }

    public int MaximumEnableSpeed
    {
        set { maximumEnableSpeed = value; }
        get { return maximumEnableSpeed; }
    }

    public int MinimumEnableSpeed
    {
        set { minimumEnableSpeed = value; }
        get { return minimumEnableSpeed; }
    }
}


public class GameManager : Singleton<GameManager>
{
    [SerializeField] float sequence = 1f;
    [SerializeField] float limitVelocity = 50;

    [SerializeField] public bool state = true;
    [SerializeField] public float speed = 20f;

    public Difficulty difficulty = new Difficulty();

    public void Init()
    {    
        speed = 20;

        state = true;
        Time.timeScale = 1.0f;

        difficulty.MinimumEnableSpeed = 0;
        difficulty.MaximumEnableSpeed = 5;


        difficulty.MaximumSpawn = 3.0f;
        difficulty.MinimumSpawn = 2.75f;

        DataManager.instance.Score = 0;
    }

    public void GameOver()
    {
        state = false;

        DataManager.instance.SetRankScore(DataManager.instance.Score);

        ResourceManager.instance.Instance("Game Over Panel", GameObject.Find("UI Canvas").transform);
    }

    public void IncreaseSequence()
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
