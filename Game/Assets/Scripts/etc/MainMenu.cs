using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Execute()
    {
        StartCoroutine(TransitionManager.instance.AsyncLoad(SceneID.GAME));
    }
}
