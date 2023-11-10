using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles;

    [SerializeField] Transform[] createPositions;
    [SerializeField] GameObject[] obstaclePrefabs;

    [SerializeField] int randSeed;
    WaitForSeconds waitForSeconds = new WaitForSeconds(5f);

    void Start()
    {
        obstacles.Capacity = 10;
        CreateObstacle();
        StartCoroutine(ActiveObstacle());
    }

    public void CreateObstacle()
    {
        for(int i = 0; i < obstaclePrefabs.Length; ++i) 
        { 
            GameObject obstacle = Instantiate(obstaclePrefabs[i]);

            obstacle.SetActive(false);

            obstacles.Add(obstacle);
        }
    }

    IEnumerator ActiveObstacle()
    {
        yield return new WaitForSeconds(0.01f);
        while (true) 
        { 
            randSeed = Random.Range(0, obstacles.Count);

            while (obstacles[randSeed].activeSelf == true)
            {
                randSeed = (randSeed + 1) % obstacles.Count;
            }

            obstacles[randSeed].transform.position = createPositions[Random.Range(0, createPositions.Length)].position;
            obstacles[randSeed].SetActive(true);

            yield return waitForSeconds;
        }
    }
}
