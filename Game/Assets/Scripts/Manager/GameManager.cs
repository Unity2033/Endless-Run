using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Execute()
    {
        State.Ready = true;

        State.OnExecute?.Invoke();
    }

    public void Finish()
    {
        State.Ready = false;

        State.OnFinish?.Invoke();
    }
}
