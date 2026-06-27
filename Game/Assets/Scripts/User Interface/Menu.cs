using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject scorePanel;
    [SerializeField] GameObject creditsPanel;

    public void Continue()
    {
        GameManager.instance.State = true;

        AudioManager.instance.Listen("Select");

        MouseManager.instance.DisableMode();
    }

    public void LeaderBoard()
    {
        creditsPanel.gameObject.SetActive(false);
        scorePanel.gameObject.SetActive(!scorePanel.activeSelf);

        DataManager.instance.Load();
        AudioManager.instance.Listen("Select");
    }

    public void Credit()
    {
        scorePanel.gameObject.SetActive(false);
        creditsPanel.gameObject.SetActive(!creditsPanel.activeSelf);

        AudioManager.instance.Listen("Select");
    }

    public void Reset()
    {
        scorePanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
}
