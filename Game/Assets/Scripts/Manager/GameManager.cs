using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Execute()
    {
        State.Publish(Condition.START);

        AudioManager.instance.Listen("Start Button");
    }

    public void Resume()
    {
        State.Publish(Condition.RESUME);

        AudioManager.instance.Listen("Continue Button");
    }

}
