using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDetector : MonoBehaviour
{
    private bool detector;

    public bool Detector
    {
        get { return detector; }
    }

    private void OnTriggerStay(Collider other)
    {
        IObstacleCollision obstacleCollision = other.GetComponent<IObstacleCollision>();

        if (obstacleCollision != null)
        {
            detector = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IObstacleCollision obstacleCollision = other.GetComponent<IObstacleCollision>();

        if (obstacleCollision != null)
        {
            detector = false;
        }
    }
}
