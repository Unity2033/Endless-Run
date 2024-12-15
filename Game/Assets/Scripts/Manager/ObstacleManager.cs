using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;

    [SerializeField] int random;
    [SerializeField] int createCount = 5;

    void Start()
    {
        Create();

        StartCoroutine(ActiveObstacle());
    }

    public void Create()
    {

        obstacles.Capacity = 10;

        for (int i = 0; i < createCount; i++)
        {
            GameObject prefab = ResourcesManager.instance.Instantiate("Cone", gameObject.transform);

            prefab.SetActive(false);

            obstacles.Add(prefab);
        }
    }

    public bool ExamineActive()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }

        return true;
    }

    public IEnumerator ActiveObstacle()
    {
        while (GameManager.instance.State)
        {
                yield return CoroutineCache.WaitForSecond(2.5f);

                random = Random.Range(0, obstacles.Count);

                // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                while (obstacles[random].activeSelf == true)
                {
                    // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                    if (ExamineActive())
                    {
                        // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ���� ������ ����
                        // obstacles ����Ʈ�� �־��ݴϴ�.
                        GameObject clone = ResourcesManager.instance.Instantiate("Cone", gameObject.transform);

                        clone.SetActive(false);

                        obstacles.Add(clone);
                    }

                    // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ������
                    // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
                    random = (random + 1) % obstacles.Count;
                }

                // �������� ������ Obstacle ������Ʈ�� Ȱ��ȭ�մϴ�.
                // obstacles[random].SetActive(true);           
        }
    }

    public GameObject GetObstacle()
    {
        return obstacles[random];
    }

}
