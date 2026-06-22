using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] float duration = 1.0f;

    [SerializeField] Image screenImage;

    public void FadeIn()
    {
        StartCoroutine(Fade(0f, 1f));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(1f, 0f));
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
    }
}
