using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum ButtonType
{
    START,
    RANKING,
    OPTION,
    QUIT
}


public class ButtonManager : MonoBehaviour
{
    [SerializeField] int createCount;
    [SerializeField] Button buttonPrefab;
    [SerializeField] Transform createPosition;

    [SerializeField] Sprite [ ] buttonSprite;
    List<Button> buttons = new List<Button>();

    void Start()
    {
        buttons.Capacity = 10;

        CreateButton();
    }

    public void CreateButton()
    {
        for (int i = 0; i < createCount; i++)
        {
            Button button = Instantiate(buttonPrefab);

            button.transform.SetParent(createPosition);

            button.GetComponent<Image>().sprite = buttonSprite[i];

            buttons.Add(button);
        }
    }

    public void GameStart()
    {
        Debug.Log("Game Start");
    }

    public void Ranking()
    {    
        Debug.Log("B");
    }

    public void Option()
    {
        AudioManager.instance.Open();
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
