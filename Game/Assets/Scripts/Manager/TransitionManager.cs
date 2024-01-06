using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneID
{ 
   TITLE,
   GAME,
   SHOP
}

public class TransitionManager : Singleton<TransitionManager>
{
    [SerializeField] float time;
    [SerializeField] Image sceneImage;
    [SerializeField] Sound sound = new Sound();

    public IEnumerator FadeIn()
    {
        Color color = sceneImage.color;

        color.a = 1;

        sceneImage.gameObject.SetActive(true);

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
        AudioManager.instance.Sound(sound.clips[0]);

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
