using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Sound sound = new Sound();

    public void NewGame()
    {
        AudioManager.instance.Sound(sound.clips[0]);

        StartCoroutine(TransitionManager.instance.AsyncLoad(SceneID.GAME));
    }

    public void Shop()
    {
        AudioManager.instance.Sound(sound.clips[0]);
    }

    public void Option()
    {
        AudioManager.instance.Sound(sound.clips[0]);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif  
    }
}
