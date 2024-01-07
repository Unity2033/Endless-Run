using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] Slider effectSlider;
    [SerializeField] Slider scenerySlider;

    public void Start()
    {
        effectSlider.value = DataManager.instance.LoadEffectVolume();
        scenerySlider.value = DataManager.instance.LoadSceneryVolume();
    }

    public void ControlSceneryVolume(float volume)
    {
        scenerySlider.value = volume;

        DataManager.instance.SaveSceneryVolume(volume);

        AudioManager.instance.Volume();
    }

    public void ControlEffectVolume(float volume)
    {
        effectSlider.value = volume;

        DataManager.instance.SaveEffectVolume(volume);

        AudioManager.instance.Volume();
    }

    public void Initialized()
    {
        DataManager.instance.DeleteData();
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
