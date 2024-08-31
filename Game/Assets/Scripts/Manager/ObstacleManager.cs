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

            // 현재 게임 오브젝트가 활성화되어 있는 지 확인합니다.
            while (obstacleList[random].activeSelf == true)
            {
                if (ExamineActive()) // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는 지 확인합니다.
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

            // obstacle 오브젝트가 생성되는 위치를 랜덤으로 설정합니다.
            obstacleList[random].transform.position = position;

            // 랜덤으로 설정된 obstacle 오브젝트를 활성화합니다.
            obstacleList[random].SetActive(true);
        }
    }
}
