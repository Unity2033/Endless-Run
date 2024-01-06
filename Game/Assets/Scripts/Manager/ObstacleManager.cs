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

                // 현재 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                while (obstacleList[random].activeSelf == true)
                {
                    if(FullObstacle()) // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                    {
                        // 모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로 생성한 다음
                        // obstacles 리스트에 넣어줍니다.
                        GameObject obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);

                        obstacle.SetActive(false);

                        obstacleList.Add(obstacle);
                    }

                    // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있지 않다면
                    // random 변수의 값을 +1을 해서 다시 검색합니다.
                    random = (random + 1) % obstacleList.Count;
                }

                // 랜덤으로 위치를 설정하는 변수 선언
                randomPosition = Random.Range(0, createPositions.Length);

                // 만약에 내가 이전에 저장되어 있던 변수와 다시 뽑은 randomPosition의 값이
                // compare 변수와 일치하다면 중복이 되지 않도록 계산합니다.
                if (compare == randomPosition)
                {
                    randomPosition = (randomPosition + 1) % createPositions.Length;
                }

                // compare 변수에 random으로 설정된 변수의 값을 넣어줍니다.
                compare = randomPosition;

                // obstacle 오브젝트가 생성되는 위치를 랜덤으로 설정합니다.
                obstacleList[random].transform.position = createPositions[compare].position;

                // 랜덤으로 설정된 obstacle 오브젝트를 활성화합니다.
                obstacleList[random].SetActive(true);
            }

            yield return CoroutineCache.waitForSeconds(Random.Range(1, 2));
        }
    }
}
