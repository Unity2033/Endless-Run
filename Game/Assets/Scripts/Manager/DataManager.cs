using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private int score = 0;
    private int bestScore;
    private int questScore;

    public int Score 
    {
        get { return score; }

        set 
        {
            score = value;
        }
    }

    public int QuestScore
    {
        get 
        {
            questScore = PlayerPrefs.GetInt("Quest Score");

            return questScore;  
        }

        set
        {
            questScore = value;

            PlayerPrefs.SetInt("Quest Score", questScore);
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

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
