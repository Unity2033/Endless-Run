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

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        state = true;
    }
}
