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

            // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
            while (obstacles[random].activeSelf == true)
            {
                // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                if (ExamineActive())
                {
                    // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ���� ������ ����
                    // obstacles ����Ʈ�� �־��ݴϴ�.
                    GameObject clone = ResourcesManager.instance.Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)], gameObject.transform);

                    clone.SetActive(false);

                    obstacles.Add(clone);
                }

                // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ������
                // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
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
