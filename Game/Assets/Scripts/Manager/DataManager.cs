using UnityEngine;
using TMPro;

public class DataManager : Singleton<DataManager>
{
    [SerializeField] float record;
    [SerializeField] TextMeshProUGUI maximumDistanceText;

    private void Start()
    {
        Load();
    }

    public void Save(float distance)
    {
        if (record < distance)
        {
            record = distance;

            PlayerPrefs.SetFloat("Distance", record);

            PlayerPrefs.Save();
        }
    }

    public void Load()
    {
        record = PlayerPrefs.GetFloat("Distance");

        maximumDistanceText.text = $"Maximum Distance : {record:F0}m";
    }
}
