using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneSound
{
    Title,
    Game,
}

public enum AudioType
{ 
    Scenery,
    Effect
}


public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] SceneSound sceneSound;
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    public void Sound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneSound = (SceneSound)scene.buildIndex;

        scenerySource.clip = Resources.Load<AudioClip>(sceneSound.ToString());

        scenerySource.loop = true;
        scenerySource.Play();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
