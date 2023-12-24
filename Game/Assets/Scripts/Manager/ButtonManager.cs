using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    [SerializeField] int createCount;
    [SerializeField] Button buttonPrefab;

    [SerializeField] List<string> textList= new List<string>();
    [SerializeField] List<Button> buttonList = new List<Button>();

    void Start()
    {
        buttonList.Capacity = 10;

        SetTextMeshPro();
    }

    public void SetTextMeshPro()
    {
        for (int i = 0; i < createCount; i++)
        {
            buttonList[i].GetComponentInChildren<TextMeshProUGUI>().text = textList[i];
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Shop()
    {    
        Debug.Log("B");
    }

    public void Option()
    {
    
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
