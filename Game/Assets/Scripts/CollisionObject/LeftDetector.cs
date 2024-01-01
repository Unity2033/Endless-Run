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
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if (obstacle != null)
        {
            detector = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if (obstacle != null)
        {
            detector = false;
        }
    }
}
