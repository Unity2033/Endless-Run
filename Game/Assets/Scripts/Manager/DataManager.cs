using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private float effectVolume = 1.0f;
    private float sceneryVolume = 1.0f;

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

    public void SaveSceneryVolume(float volume)
    {
        sceneryVolume = volume;

        PlayerPrefs.SetFloat("Scenery Volume", sceneryVolume);
    }

    public void SaveEffectVolume(float volume)
    {
        effectVolume = volume;

        PlayerPrefs.SetFloat("Effect Volume", effectVolume);
    }

    public float LoadSceneryVolume()
    {
        return PlayerPrefs.GetFloat("Scenery Volume");
    }

    public float LoadEffectVolume()
    {
        return PlayerPrefs.GetFloat("Effect Volume");
    }
}
