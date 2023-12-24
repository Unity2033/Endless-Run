using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{    
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    public void Sound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
}
