using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        StartCoroutine(TransitionManager.instance.AsyncLoad(SceneID.GAME));
    }

    public void Shop()
    {    
        Debug.Log("B");
    }

    public void Option()
    {
    
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
