using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Vector3[] randomVector3 = new Vector3[3];

    private void Awake()
    {
        randomVector3[0] = new Vector3(-4, 0, 0);
        randomVector3[1] = new Vector3(0, 0, 0);
        randomVector3[2] = new Vector3(4, 0, 0);
    }

    private void OnEnable()
    {
        transform.position = randomVector3[Random.Range(0, randomVector3.Length)];
    }
}
