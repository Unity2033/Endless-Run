using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] GameObject platform;

    void Start()
    {
        // Instantiate : ���� ������Ʈ�� �����ϴ� �Լ�
        // ù ��° �Ű����� : �����ϰ� ���� ���� ������Ʈ
        // �� ��° �Ű����� : ���� ������Ʈ�� ��ġ
        // �� ��° �Ű����� : ���� ������Ʈ�� ȸ��

        Instantiate
        (
            platform,
            transform.position,
            Quaternion.identity
        );
    }
}
