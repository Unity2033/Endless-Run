using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Road road = other.GetComponent<Road>();

        if(road != null)
        {
            road.Activate();
        }    
    }
}
