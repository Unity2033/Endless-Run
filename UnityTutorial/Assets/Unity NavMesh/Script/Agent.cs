using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    #region �迭
    // ���� �ڷ����� ������� �̷���� ���� �����Դϴ�.

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

        // �迭�� ��� ù ��° ���Ҵ� 0���� �����ϸ�, �迭��
        // ���ϴ� ���ҿ� ���ϴ� ���� ������ �� �ֽ��ϴ�.

        // �迭�� ũ��� �������� �Ǵ� �������� ������
        // �޸� ������ ������ �˴ϴ�.

        for (int i = 0; i < buffer.Length; i++)
        {
            Debug.Log(buffer[i]);
        }

        // InvokeRepeating : Ư���� �ð� �� Ư���� �ð����� �Լ��� �ݺ������� ȣ���ϴ� �Լ��Դϴ�
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
