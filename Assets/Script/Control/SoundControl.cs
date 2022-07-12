using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public static SoundControl Instance;

    private AudioSource audioSource;
    public AudioClip [] audioClip;

    void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // name ã�Ƽ� 
    public void SoundCall(string name)
    {
        // �츮�� �Է��� string(���ڿ�)�� ���� ���ϴ� ���带 ����ϵ��� �����մϴ�.
        switch (name)
        {
            case "Collision":
                audioSource.clip = audioClip[0];
                audioSource.Play();
                break;
            case "Move":
                audioSource.clip = audioClip[1];
                audioSource.Play();
                break;
            case "Level Up":
                audioSource.clip = audioClip[2];
                audioSource.Play();
                break;
        }
    }
}
