using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0.0f;
        Instantiate(Resources.Load<GameObject>("Pause Panel"), GameObject.Find("UI Canvas").transform);
    }
}
