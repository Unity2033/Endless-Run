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

    private void OnEnable()
    {
        State.OnFinish += EnableMouse;

        State.OnExecute += DisableMouse;
    }

    private void Start()
    {
        EnableMouse();

        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void DisableMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EnableMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnDisable()
    {
        State.OnFinish -= EnableMouse;

        State.OnExecute += DisableMouse;
    }
}