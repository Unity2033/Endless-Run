using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Text bestScoreText;
    [SerializeField] Text challengeText;
    [SerializeField] Button resumeButton;

    public void Start()
    {
        if (DataManager.instance.BestScore < DataManager.instance.Score)
        {
            challengeText.text = "Success";
            challengeText.color = Color.green;
            DataManager.instance.BestScore = DataManager.instance.Score;
        }
        else
        {
            challengeText.text = "Failure";
            challengeText.color = Color.white;
        }

        RenewalRank();
    }

    public void RenewalRank()
    {
        bestScoreText.text = DataManager.instance.BestScore.ToString() +"m";
    }

    public void Resume()
    {
        resumeButton.interactable = false;
        StartCoroutine(TransitionManager.instance.AsyncLoad(SceneID.GAME));
    }
}
