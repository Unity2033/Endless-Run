using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneSound
{
    Title,
    Game,
    Shop
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

    public void Mute(string sourceName, bool flag)
    {
        switch(sourceName)
        {
            case "Scenery" : scenerySource.mute = flag;
                break;
            case "Effect": effectSource.mute = flag;
                break;
        }
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
