using UnityEngine;

public class MainMenu : MonoBehaviour
{
    GameObject missionPanel;
    [SerializeField] Animator animator;
    [SerializeField] Sound sound = new Sound();

    public void Execute()
    {
        animator.SetTrigger("Start");
        StartCoroutine(TransitionManager.instance.AsyncLoad(SceneID.GAME));
    }

    public void Quest()
    {
        AudioManager.instance.Sound(sound.clips[0]);

        if (missionPanel == null)
        {
            missionPanel = ResourceManager.instance.Instance("Mission Panel", GameObject.Find("Main Menu Canvas").transform);
        }
        else
        {
            missionPanel.SetActive(true);
        }
    }
}
