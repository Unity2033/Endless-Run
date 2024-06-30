using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IHitable clone = other.GetComponent<IHitable>();

        if(clone != null)
        {
            clone.Activate();
        }    
    }
}
