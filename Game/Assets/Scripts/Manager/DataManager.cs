using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] int distance;

    public void Save()
    {
        PlayerPrefs.SetInt("Distance", distance);

        PlayerPrefs.Save();
    }

    public void Load()
    {
        distance = PlayerPrefs.GetInt("Distance");
    }


}
