using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableZone : MonoBehaviour, IObstacleCollision
{
    public void Activate(GameObject obstacle)
    {
        obstacle.SetActive(false);
    }
}
