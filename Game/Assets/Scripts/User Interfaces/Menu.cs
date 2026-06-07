using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void Launch()
    {
        AudioManager.instance.Listen("Start Button");

        SceneryManager.instance.LoadScene("Game");
    }

    public void Credit()
    {
        AudioManager.instance.Listen("Start Button");

    }

    public void Option()
    {
        AudioManager.instance.Listen("Start Button");
    }

}
