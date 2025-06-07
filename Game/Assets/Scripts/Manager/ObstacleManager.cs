using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] Transform[] transforms;
    [SerializeField] List<GameObject> obstacles;

    [SerializeField] List<string> obstacleNames;

    [SerializeField] int random;
    [SerializeField] int createCount = 5;

    [SerializeField] float obstacleDelay = 1.0f;


    private void OnEnable()
    {
        State.Subscribe(Condition.START, Execute);
        State.Subscribe(Condition.FINISH, Release);
    }

    void Start()
    {
        obstacles.Capacity = 10;

        Create();
    }

    public void Create()
    {
        GameObject clone = Instantiate(Resources.Load<GameObject>(obstacleNames[Random.Range(0, obstacleNames.Count)]), transform);

        clone.name = clone.name.Replace("(Clone)", "");

        clone.SetActive(false);

        obstacles.Add(clone);       
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
        while (true)
        {
            random = Random.Range(0, obstacles.Count);

            // 현재 게임 오브젝트가 활성화되어 있는 지 확인합니다.
            while (obstacles[random].activeSelf == true)
            {
                // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                if (ExamineActive())
                {
                    // 모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로 생성한 다음
                    // obstacles 리스트에 넣어줍니다.
                    Create();
                }

                // 현재 인덱스에 있는 게임 오브젝트가 활성화되어 있으면
                // random 변수의 값을 +1을 해서 다시 검색합니다.
                random = (random + 1) % obstacles.Count;
            }

            obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;

            obstacles[random].SetActive(true);

            yield return CoroutineCache.WaitForSecond(obstacleDelay);

            obstacleDelay = Mathf.Max(0.125f, obstacleDelay - 0.025f);
        }
    }

    public void Execute()
    {
        StartCoroutine(ActiveObstacle());
    }

    void Release()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        State.Unsubscribe(Condition.START, Execute);
        State.Unsubscribe(Condition.FINISH, Release);

    }
}
