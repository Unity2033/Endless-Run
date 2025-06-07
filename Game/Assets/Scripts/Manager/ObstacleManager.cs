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

            // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
            while (obstacles[random].activeSelf == true)
            {
                // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                if (ExamineActive())
                {
                    // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ���� ������ ����
                    // obstacles ����Ʈ�� �־��ݴϴ�.
                    Create();
                }

                // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ������
                // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
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
