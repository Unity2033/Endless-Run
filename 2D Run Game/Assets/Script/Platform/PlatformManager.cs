using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private WaitForSeconds wait = new WaitForSeconds(5);

    void Start()
    {
        StartCoroutine(CreateObject());  
    }

    IEnumerator CreateObject()
    {
        while(true)
        {
            ObjectPoolManager.instance.GetQueue();

            yield return wait;
        }
    }
}
