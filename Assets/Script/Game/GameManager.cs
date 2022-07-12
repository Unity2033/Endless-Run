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

        StartCoroutine(SpeedIncrease());
    }

    IEnumerator SpeedIncrease()
    {
        // while ������ ���̶�� ���� �ݺ��ϴ� �ݺ����Դϴ�.
        while(state)
        {
            // 1�� ���� ����մϴ�.
            yield return new WaitForSeconds(1f);
            speed++;

            if(state == false)
            {
                speed = 0;
            }

            if(speed >= 50)
            {
                speed = 50;
            }
        }
    }


}
