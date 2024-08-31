using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] ObstacleManager obstacleManager;

    void OnEnable()
    {
        StartCoroutine(obstacleManager.ActiveObstacle(transform.position));
    }
}
