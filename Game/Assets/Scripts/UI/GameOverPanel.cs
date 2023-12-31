using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] List<TextMeshProUGUI> scoreList;

    public void Start()
    {
        scoreList.Capacity = 5;

        RenewalRank();
    }

    public void RenewalRank()
    {
        for (int i = 0; i < scoreList.Count; i++)
        {
            scoreList[i].text = DataManager.instance.GetRankScore(i).ToString();
        };
    }

    public void Resume()
    {
        resumeButton.interactable = false;
        StartCoroutine(TransitionManager.instance.AsyncLoad(SceneID.GAME));
    }
}
