using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private int score = 0;
    private List<int> rankScore = new List<int>();

    private float sceneryVolume = 1.0f;
    private float effectVolume = 1.0f;

    private void Start()
    {
        rankScore.Capacity = 5; 

        for(int i = 0; i < 3; i++)
        {
            rankScore.Add(0);
        }
    }

    public int Score 
    {
        get { return score; }
        set { score = value; }
    }

    public void SetRankScore(int currentScore)
    {
        for (int i = 0; i < rankScore.Count; i++)
        {
            rankScore[i] = PlayerPrefs.GetInt("Rank Score " + i);
        }

        if (rankScore[rankScore.Count-1] < currentScore)
        {
            rankScore[rankScore.Count - 1] = currentScore;
            PlayerPrefs.SetInt("Rank Score " + rankScore[rankScore.Count - 1], rankScore[rankScore.Count - 1]);      
        }
        
        rankScore.Sort();
        rankScore.Reverse();

        for (int i = 0; i < rankScore.Count; i++)
        {
            PlayerPrefs.SetInt("Rank Score " + i, rankScore[i]);
        }
    }

    public int GetRankScore(int i)
    {
        return PlayerPrefs.GetInt("Rank Score " + i.ToString());      
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
