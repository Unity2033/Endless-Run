using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : Singleton<MouseManager>
{
    [SerializeField] Texture2D texture2D;

    private void Start()
    {
        texture2D = Resources.Load<Texture2D>("Sprites/Default");

        EnableMode();

        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void DisableMode()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EnableMode()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}