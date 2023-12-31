using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;

    public void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    public void RenewalUI()
    {
        scoreText.text = DataManager.instance.Score.ToString() + "m";
    }
}
