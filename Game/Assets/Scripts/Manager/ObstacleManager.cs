using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacleList;

    [SerializeField] Transform [] createPositions;
    [SerializeField] GameObject [] obstaclePrefabs;

    [SerializeField] int random;
    [SerializeField] int compare;
    [SerializeField] int createCount;
    [SerializeField] int randomPosition;

    void Start()
    {
        obstacleList.Capacity = 10;

        createCount = createPositions.Length;

        CreateObstacle();
        StartCoroutine(ActiveObstacle());
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

    public bool FullObstacle()
    {
        for(int i = 0; i < obstacleList.Count; i++)
        {
            if(obstacleList[i].activeSelf == false)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator ActiveObstacle()
    {
        while (GameManager.instance.state) 
        {
            for (int i = 0; i < Random.Range(1, createCount); i++)
            {
                random = Random.Range(0, obstacleList.Count);

                // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                while (obstacleList[random].activeSelf == true)
                {
                    if(FullObstacle()) // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
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

                // �������� ��ġ�� �����ϴ� ���� ����
                randomPosition = Random.Range(0, createPositions.Length);

                // ���࿡ ���� ������ ����Ǿ� �ִ� ������ �ٽ� ���� randomPosition�� ����
                // compare ������ ��ġ�ϴٸ� �ߺ��� ���� �ʵ��� ����մϴ�.
                if (compare == randomPosition)
                {
                    randomPosition = (randomPosition + 1) % createPositions.Length;
                }

                // compare ������ random���� ������ ������ ���� �־��ݴϴ�.
                compare = randomPosition;

                // obstacle ������Ʈ�� �����Ǵ� ��ġ�� �������� �����մϴ�.
                obstacleList[random].transform.position = createPositions[compare].position;

                // �������� ������ obstacle ������Ʈ�� Ȱ��ȭ�մϴ�.
                obstacleList[random].SetActive(true);
            }

            yield return CoroutineCache.waitForSeconds(Random.Range(1, 2));
        }
    }
}
