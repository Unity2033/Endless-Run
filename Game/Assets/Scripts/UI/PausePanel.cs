using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    GameObject optionPanel;
    [SerializeField] Sound sound = new Sound();

    public void Resume()
    {
        AudioManager.instance.Sound(sound.clips[0]);

        Time.timeScale = 1.0f;

        gameObject.SetActive(false);
    }

    public void Setting()
    {
        AudioManager.instance.Sound(sound.clips[0]);

        if (optionPanel == null)
        {
            optionPanel = ResourceManager.instance.Instance("Option Panel", GameObject.Find("UI Canvas").transform);
        }
        else
        {
            optionPanel.SetActive(true);
        }
    }

    public void Quit()
    {
        Time.timeScale = 1.0f;

        AudioManager.instance.Sound(sound.clips[0]);

        StartCoroutine(TransitionManager.instance.AsyncLoad(SceneID.TITLE));
    }
}
