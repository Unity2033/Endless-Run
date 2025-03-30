using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Action keyAction;

    private void Update()
    {
        if (GameManager.instance.State == false) return;

        if (Input.anyKey == false)
        {
            return;
        }

        keyAction?.Invoke();
    }
}
