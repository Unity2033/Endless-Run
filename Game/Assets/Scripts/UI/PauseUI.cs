using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    GameObject pausePanel;

    [SerializeField] Sound sound = new Sound();

    public void Pause()
    {
        AudioManager.instance.Sound(sound.clips[0]);

        Time.timeScale = 0.0f;

        if (pausePanel == null)
        {
            pausePanel = ResourceManager.instance.Instance("Pause Panel", GameObject.Find("UI Canvas").transform);
        }
        else
        {
            pausePanel.SetActive(true);
        }
    }
}
