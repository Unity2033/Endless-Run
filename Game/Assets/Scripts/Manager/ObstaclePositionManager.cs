using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePositionManager : MonoBehaviour
{
    [SerializeField] int index = -1;
    [SerializeField] Transform[] parentRoad;

    [SerializeField] float[] randomPositionZ = new float[16];

    private void Awake()
    {
        for (int i = 0; i < randomPositionZ.Length; i++)
        {
            randomPositionZ[i] = i * 2.5f + -10.0f;
        }
    }

    private void Start()
    {
        StartCoroutine(SetPosition());
    }

    private IEnumerator SetPosition()
    {
        while (true)
        {
            yield return CoroutineCache.WaitForSecond(2.5f);

            transform.localPosition = new Vector3(0, 0, randomPositionZ[Random.Range(0, randomPositionZ.Length)]);
        }
    }

    public void InitializePosition()
    {
        index = (index + 1) % parentRoad.Length;

        transform.SetParent(parentRoad[index]);

        transform.localPosition += new Vector3(0, 0, 40);
    }
}