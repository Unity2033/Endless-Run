using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] Image effectSound;
    [SerializeField] Image scenerySound;

    private bool effectToggle = true;
    private bool sceneryToggle = true;

    private int effectPower;
    private int sceneryPower;

    private void OnEnable()
    {
        effectPower = PlayerPrefs.GetInt("Effect Power");
        sceneryPower = PlayerPrefs.GetInt("Scenery Power");

        effectToggle = Convert.ToBoolean(effectPower);
        effectSound.sprite = Resources.Load<Sprite>("Sound " + effectToggle);

        sceneryToggle = Convert.ToBoolean(sceneryPower);
        scenerySound.sprite = Resources.Load<Sprite>("Sound " + sceneryToggle);
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
