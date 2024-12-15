using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] float offset = 40.0f;
    [SerializeField] List<GameObject> roads;

    public void Start()
    {
        roads.Capacity = 10;
    }

    void Update()
    {
        if (GameManager.instance.State == false) return;

        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * SpeedManager.Speed * Time.deltaTime);
        }
    }

    public void InitializePosition()
    {
        GameObject newRoad = roads[0];
        roads.Remove(newRoad);

        float newZ = roads[roads.Count-1].transform.position.z + offset;
        newRoad.transform.position = new Vector3(0, 0, newZ);
        
        roads.Add(newRoad);
    }
}
