using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Execute()
    {
        GameManager.instance.Execute();

        StartCoroutine(SceneryManager.instance.AsyncLoad(1));
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
