using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private Coroutine coroutine;

    [SerializeField] int createCount = 5;

    [SerializeField] Transform[] transforms;

    [SerializeField] List<string> obstacleNames;

    [SerializeField] Queue<GameObject> obstacles = new();


    void Start()
    {
        Create();
    }

    public void Create()
    {
        GameObject clone = Instantiate(Resources.Load<GameObject>("Prefabs/" + obstacleNames[Random.Range(0, obstacleNames.Count)]), transform);

        clone.name = clone.name.Replace("(Clone)", "");

        clone.SetActive(false);

        obstacles.Enqueue(clone);       
    }

    public void Return(GameObject obstacle)
    {
        obstacle.SetActive(false);

        obstacles.Enqueue(obstacle);
    }

    public IEnumerator ActiveObstacle()
    {
        while (GameManager.instance.State)
        {
            if(obstacles.Count <= 0)
            {
                Create();
            }

            GameObject obstacle = obstacles.Dequeue();

            obstacle.transform.position = transforms[Random.Range(0, transforms.Length)].position;

            obstacle.SetActive(true);

            float ratio = (GameManager.instance.Speed - GameManager.instance.InitializeSpeed) / (60f - GameManager.instance.InitializeSpeed);

            yield return CoroutineCache.WaitForSecond(Mathf.Lerp(1.0f, 0.3f, ratio));
        }
    }

    public void Deactivate()
    {
        if(coroutine != null)
        {
            StopCoroutine(ActiveObstacle());

            coroutine = null;
        }

        obstacles.Clear();

        foreach (Transform clone in transform)
        {
            clone.gameObject.SetActive(false);

            obstacles.Enqueue(clone.gameObject);
        }
    }

    public void Execute()
    {
        coroutine = StartCoroutine(ActiveObstacle());
    }
}
