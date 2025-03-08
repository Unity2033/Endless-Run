using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSearch : MonoBehaviour
{
    public void Disable()
    {
        Obstacle[] obstacles = GetComponentsInChildren<Obstacle>();

        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.gameObject.SetActive(false);
        }
    }
}
