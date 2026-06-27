using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    private Coroutine coroutine;

    [SerializeField] float duration = 1.0f;

    [SerializeField] Image screenImage;

    public void FadeIn()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(Fade(screenImage.color.a, 1f));
    }

    public void FadeOut()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(Fade(screenImage.color.a, 0f));
    }

    IEnumerator Fade(float start, float end)
    {
        float time = 0;

        Color color = screenImage.color;

        while (time < duration)
        {
            time += Time.deltaTime;

            color.a = Mathf.Lerp(start, end, time / duration);
            screenImage.color = color;

            yield return null;
        }

        color.a = end;
        screenImage.color = color;

        coroutine = null;
    }
}
