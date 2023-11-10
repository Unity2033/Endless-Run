using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{    
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;

    [SerializeField] GameObject optionPanel;


    private void Start()
    {
        LoadVolume();
    }


    public void Sound(AudioClip clip)
    {        
        sfxSource.PlayOneShot(clip);
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        SaveVolume();
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        SaveVolume();
    }

    public void Close()
    {
        optionPanel.SetActive(false);
    }

    public void Open()
    {
        optionPanel.SetActive(true);
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("BGM Volume", bgmSource.volume);
        PlayerPrefs.SetFloat("SFX Volume", sfxSource.volume);
    }

    public void LoadVolume()
    {
        bgmSource.volume = PlayerPrefs.GetFloat("BGM Volume");
        sfxSource.volume = PlayerPrefs.GetFloat("SFX Volume");
    }

}
