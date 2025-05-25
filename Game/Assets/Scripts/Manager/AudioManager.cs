using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    private void Start()
    {
        scenerySource.loop = true;
    }

    public void Listen(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void ScenerySound(string name)
    {
        scenerySource.clip = Resources.Load<AudioClip>(name);

        scenerySource.Play();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
         ScenerySound(scene.name);
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
