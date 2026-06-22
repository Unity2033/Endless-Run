using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Road : MonoBehaviour
{
    [SerializeField] UnityEvent callback;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interact Zone"))
        {
            if (callback != null)
            {
                callback.Invoke();
            }
        }
    }
}