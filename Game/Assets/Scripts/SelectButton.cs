using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] Text buttonText;
    [SerializeField] Sound sound = new Sound();

    void Awake()
    {
        buttonText = GetComponentInChildren<Text>();
    }

    public void OnEnter()
    {
        buttonText.fontSize = 85;
        AudioManager.instance.Sound(sound.clips[0]);
    }

    public void OnLeave()
    {
        buttonText.fontSize = 75;
    }

    public void OnSelect()
    {
        buttonText.fontSize = 50;
        AudioManager.instance.Sound(sound.clips[1]);
    }
}
