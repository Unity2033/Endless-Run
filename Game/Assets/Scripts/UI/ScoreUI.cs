using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;

    public void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    private void Start()
    {
        //StartCoroutine(IncreaseScore());
    }

    public void RenewalUI()
    {
        scoreText.text = DataManager.instance.Score.ToString() + "m";
    }

    //public IEnumerator IncreaseScore()
    //{
    //    // while(GameManager.instance.state)
    //    // {
    //    //     yield return new WaitForSeconds(0.25f);
    //    // 
    //    //     if (GameManager.instance.state == false)
    //    //     {
    //    //         yield break;
    //    //     }
    //    // 
    //    //     DataManager.instance.Score += 10;
    //    // 
    //    //     RenewalUI();
    //    // }
    //}
}
