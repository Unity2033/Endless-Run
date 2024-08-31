using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : State
{
    [SerializeField] List<GameObject> obstacleList;

    [SerializeField] GameObject [ ] obstaclePrefabs;

    [SerializeField] int random;


    void Awake()
    {
        obstacleList.Capacity = 20;

        CreateObstacle();
    }

    public void CreateObstacle()
    {
        for(int i = 0; i < obstaclePrefabs.Length; ++i) 
        { 
            GameObject obstacle = Instantiate(obstaclePrefabs[i]);

            obstacle.SetActive(false);

            obstacleList.Add(obstacle);
        }
    }

    public bool ExamineActive()
    {
        for (int i = 0; i < obstacleList.Count; i++)
        {
            if(obstacleList[i].activeSelf == false)
            {
                return false;
            }
        }

        return true;
    }

    public IEnumerator ActiveObstacle(Vector3 position)
    {
        while (true)
        {
            yield return CoroutineCache.waitForSeconds(Random.Range(1, 5));

            random = Random.Range(0, obstacleList.Count);

            // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
            while (obstacleList[random].activeSelf == true)
            {
                if (ExamineActive()) // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                {
                    // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ���� ������ ����
                    // obstacles ����Ʈ�� �־��ݴϴ�.
                    GameObject obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);

                    obstacle.SetActive(false);

                    obstacleList.Add(obstacle);
                }

                // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ���� �ʴٸ�
                // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
                random = (random + 1) % obstacleList.Count;
            }

            // obstacle ������Ʈ�� �����Ǵ� ��ġ�� �������� �����մϴ�.
            obstacleList[random].transform.position = position;

            // �������� ������ obstacle ������Ʈ�� Ȱ��ȭ�մϴ�.
            obstacleList[random].SetActive(true);
        }
    }
}
