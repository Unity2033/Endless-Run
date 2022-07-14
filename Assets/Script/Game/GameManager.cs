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

    void Start()
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
    }

    public void Load()
    {
        coin = PlayerPrefs.GetInt("Coin");
    }
}
