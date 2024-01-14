using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if(obstacle != null)
        {
            obstacle.GetComponent<Obstacle>().Speed = transform.parent.GetComponent<Obstacle>().Speed;
        }
    }
}
