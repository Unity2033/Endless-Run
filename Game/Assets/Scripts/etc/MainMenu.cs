using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Execute()
    {
        StartCoroutine(TransitionManager.instance.AsyncLoad(SceneID.GAME));
    }

    public void Shop()
    {
        Debug.Log("Shop");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
