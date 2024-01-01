using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneID
{ 
   TITLE,
   GAME
}

public class TransitionManager : Singleton<TransitionManager>
{
    [SerializeField] float time;
    [SerializeField] Image sceneImage;

    public IEnumerator FadeIn()
    {
        sceneImage.gameObject.SetActive(true);

        Color color = sceneImage.color;

        color.a = 1;

        while (color.a >= 0.0f)
        {
            color.a -= Time.unscaledDeltaTime;

            sceneImage.color = color;

            yield return null;
        }

        sceneImage.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(SceneID sceneID)
    {
        sceneImage.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)sceneID);

        asyncOperation.allowSceneActivation = false;

        Color color = sceneImage.color;

        color.a = 0;

        while (asyncOperation.isDone == false)
        {
            color.a += Time.unscaledDeltaTime;

            sceneImage.color = color;

            if (asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.unscaledDeltaTime);

                if (color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
            }

            yield return null;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIn());
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
