using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager :MonoBehaviour
{
    [SerializeField] Texture2D texture2D;

    void Awake()
    {
        texture2D = Resources.Load<Texture2D>("Default");
    }

    private void Start()
    {
        State(0);
    }

    public void State(int state)
    {
        switch (state)
        {
            case 0:
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            case 1:
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
        }

        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }
}