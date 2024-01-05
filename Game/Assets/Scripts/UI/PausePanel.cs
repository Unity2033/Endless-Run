using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1.0f;

        gameObject.SetActive(false);
    }

    public void Setting()
    {

    }

    public void Quit()
    {
        StartCoroutine(TransitionManager.instance.AsyncLoad(SceneID.TITLE));
    }
}
