using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    #region 배열
    // 같은 자료형의 변수들로 이루어진 유한 집합입니다.

    private int [] buffer = new int[3];


    #endregion

    private int count = 0;
    public Transform [] pointBuffer;
    public NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent.enabled = false;
    }

    void Start()
    {
        navMeshAgent.enabled = true;
        transform.position = Vector3.zero;

        // 배열의 경우 첫 번째 원소는 0부터 시작하며, 배열은
        // 원하는 원소에 원하는 값을 저장할 수 있습니다.

        // 배열의 크기는 컴파일이 되는 시점부터 고정된
        // 메모리 공간을 가지게 됩니다.

        for (int i = 0; i < buffer.Length; i++)
        {
            Debug.Log(buffer[i]);
        }

        // InvokeRepeating : 특정한 시간 후 특정한 시간마다 함수를 반복적으로 호출하는 함수입니다
        InvokeRepeating(nameof(IncreaseCount), 0, 5);
    }

    public void IncreaseCount()
    {
        count++;
        count = count % pointBuffer.Length;
    }
    
    void Update()
    {
        navMeshAgent.SetDestination(pointBuffer[count].position);
    }
}
