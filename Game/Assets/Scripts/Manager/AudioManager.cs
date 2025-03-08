using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    public void Listen(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scenerySource.clip = ResourcesManager.instance.Load<AudioClip>(scene.name);

        scenerySource.loop = true;
        scenerySource.Play();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
