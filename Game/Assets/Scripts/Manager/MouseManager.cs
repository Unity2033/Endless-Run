using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : Singleton<MouseManager>
{
    [SerializeField] Texture2D texture2D;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void State(int state)
    {
        switch (state)
        {
            case 0:
                {
                    texture2D = ResourcesManager.instance.Load<Texture2D>("Default");
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
                }
                break;
            case 1:
                {
                    texture2D = ResourcesManager.instance.Load<Texture2D>("Default");
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
                }
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        State(scene.buildIndex);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
