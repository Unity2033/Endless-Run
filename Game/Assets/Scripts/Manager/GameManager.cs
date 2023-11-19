using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public float speed = 20f;
    [SerializeField] GameObject layoutPanel;
    [SerializeField] GameObject gameOverPanel;

    void Start()
    {
        //GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;        
    }

    public void Retry()
    {
        // SceneManager.GetActiveScene().name은 현재 씬의 이름을 의미합니다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }


}
