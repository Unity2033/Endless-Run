using System;
using System.Collections;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private Coroutine coroutine;

    [SerializeField] float duration = 1.0f;

    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    private void Start()
    {
        scenerySource.loop = true;

        scenerySource.clip = Resources.Load<AudioClip>("Audios/" + "Game");

        scenerySource.Play();
    }

    public void Listen(string name)
    {
        effectSource.PlayOneShot(Resources.Load<AudioClip>("Audios/" + name));
    }

    public void Stop()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float startVolume = scenerySource.volume;

        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            scenerySource.volume = Mathf.Lerp(startVolume, 0f, time / duration);

            yield return null;
        }

        scenerySource.Stop();

        scenerySource.volume = startVolume;

        scenerySource.Play();

        coroutine = null;
    }
}
