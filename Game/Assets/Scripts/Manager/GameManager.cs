using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool state;

    public bool State
    {
        get { return state; }
    }

    public void Execute()
    {
        state = true;
    }

    public void Finish()
    {
        state = false;

        SpeedManager.Speed = 0;

        MouseManager.instance.State(0);
    }
}
