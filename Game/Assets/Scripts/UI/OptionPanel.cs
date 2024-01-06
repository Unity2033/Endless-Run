using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    private bool effectSwitch = true;
    private bool scenerySwitch = true;

    [SerializeField] Image effectToggleImage;
    [SerializeField] Image sceneryToggleImage;

    public void SceneryToggle()
    {
        scenerySwitch = !scenerySwitch;

        sceneryToggleImage.sprite = ResourceManager.instance.Load<Sprite>("Sound " + scenerySwitch);

        AudioManager.instance.Mute("Scenery", !scenerySwitch);
    }

    public void EffectToggle()
    {
        effectSwitch = !effectSwitch;
        
        effectToggleImage.sprite = ResourceManager.instance.Load<Sprite>("Sound " + effectSwitch);

        AudioManager.instance.Mute("Effect", !effectSwitch);
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
