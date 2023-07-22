using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{ 
    JUMP,
    DIE
}


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioClip [] audioClip;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Sound(SoundType type)
    {
        audioSource.PlayOneShot(audioClip[(int)type]);
    }
}
