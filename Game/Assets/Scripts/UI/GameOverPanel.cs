using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Text bestScoreText;
    [SerializeField] Button resumeButton;

    public void OnEnable()
    {
        DataManager.instance.RenewalBestScore();

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
