using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    GameObject pausePanel;

    public void Pause()
    {
        Time.timeScale = 0.0f;

        if (pausePanel == null)
        {
            pausePanel = Instantiate(Resources.Load<GameObject>("Pause Panel"), GameObject.Find("UI Canvas").transform);
        }
        else
        {
            pausePanel.SetActive(true);
        }
    }
}
