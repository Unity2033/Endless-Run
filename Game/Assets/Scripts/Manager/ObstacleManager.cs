using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] Transform[] transforms;
    [SerializeField] List<GameObject> obstacles;

    [SerializeField] List<string> obstacleNames;

    [SerializeField] int random;
    [SerializeField] int createCount = 5;

    [SerializeField] float comeOutTime = 2.0f;
    [SerializeField] float decreaseRate = 0.95f;


    private void OnEnable()
    {
        State.OnExecute += Execute;
    }

    void Start()
    {
        obstacles.Capacity = 10;

        Create();
    }

    public void Create()
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject prefab = ResourcesManager.instance.Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)], gameObject.transform);

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
        while (State.Ready)
        {
            yield return CoroutineCache.WaitForSecond(comeOutTime);

            random = Random.Range(0, obstacles.Count);

            // 현재 게임 오브젝트가 활성화되어 있는 지 확인합니다.
            while (obstacles[random].activeSelf == true)
            {
                // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                if (ExamineActive())
                {
                    // 모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로 생성한 다음
                    // obstacles 리스트에 넣어줍니다.
                    GameObject clone = ResourcesManager.instance.Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)], gameObject.transform);

                    clone.SetActive(false);

                    obstacles.Add(clone);
                }

                // 현재 인덱스에 있는 게임 오브젝트가 활성화되어 있으면
                // random 변수의 값을 +1을 해서 다시 검색합니다.
                random = (random + 1) % obstacles.Count;
            }

            obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;

            obstacles[random].SetActive(true);

            comeOutTime = Mathf.Max(0.125f, comeOutTime * decreaseRate);
        }
    }

    public void Execute()
    {
        StartCoroutine(ActiveObstacle());
    }

    private void OnDisable()
    {   
        State.OnExecute -= Execute;
    }
}
