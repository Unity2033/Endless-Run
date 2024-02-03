using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private int score = 0;
    private int bestScore;

    public int Score 
    {
        get { return score; }

        set 
        {
            score = value;
        }
    }

    public int BestScore
    {
        get
        {
            bestScore = PlayerPrefs.GetInt("Best Score");

            return bestScore;
        }

        set
        {
            bestScore = value;

            PlayerPrefs.SetInt("Best Score", bestScore);
        }
    }

    public void RenewalBestScore()
    {
        if (BestScore < Score)
        {
           BestScore = Score;
        }
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
