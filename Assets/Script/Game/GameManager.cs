using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // static : ���α׷��� ����� ������ �޸𸮿��� ����ֽ��ϴ�.
    // static�� ������ ������ ����˴ϴ�.

    public static GameManager instance;

    public float speed;
    public bool state;
    public int coin;
    public int hat;
    public int rod;

    void Awake()
    {
        Load();

        if (instance == null)
        {
            instance = this;
        }

        state = true;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.SetInt("Hat", hat);
        PlayerPrefs.SetInt("Rod", rod);
    }

    public void Load()
    {
        coin = PlayerPrefs.GetInt("Coin");
        hat = PlayerPrefs.GetInt("Hat");
        rod = PlayerPrefs.GetInt("Rod");
    }
}
