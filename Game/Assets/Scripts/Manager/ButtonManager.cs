using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] int createCount;
    [SerializeField] Button buttonprefab;
    [SerializeField] Transform createPosition;
    [SerializeField] List<string> buttonTexts;    

    List<Button> buttons = new List<Button>();    
    Button button;
    
    void Start()
    {
        buttons.Capacity = 10;
        CreateButton();
        Register();
    }

    public void CreateButton()
    {
        for (int i = 0; i < createCount; i++)
        {
            button = Instantiate(buttonprefab);

            button.transform.SetParent(createPosition);

            button.GetComponentInChildren<TextMeshProUGUI>().text = buttonTexts[i];

            buttons.Add(button);
        }

    }


    private void Register()
    {        
        buttons[0].onClick.AddListener(StartGame);            
        buttons[1].onClick.AddListener(B);             
        buttons[2].onClick.AddListener(Option);               
        buttons[3].onClick.AddListener(Quit); 
    }

    public void StartGame()
    {
        //Debug.Log("Start");
        StartCoroutine(GameManager.instance.StartRoutine(4));        
    }

    public void B()
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
