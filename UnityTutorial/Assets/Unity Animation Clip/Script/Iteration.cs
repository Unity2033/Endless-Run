using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iteration : MonoBehaviour
{
    #region 반복문
    // 프로그램 내에서 특정한 작업을 반복적으로
    // 수행하는 명령문입니다.
    #endregion

    void Start()
    {
        // for문
        // 초기식을 연산하여 조건식의 결과에 따라 특정한
        // 횟수만큼 반복하는 반복문입니다.

        for (int i = 0; i < 5; i++) 
        {
            Debug.Log("1");
        }
    }
}
