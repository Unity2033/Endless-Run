using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads; 
    
    [SerializeField] int count = 0;
    [SerializeField] int maxCount = 15;
    [SerializeField] float offset = 40.0f;

    public static Action roadCallBack;

    public void Start()
    {
        roads.Capacity = 10;
        roadCallBack = NewPosition;
        roadCallBack += Increase;
    }

    void Update()
    {
        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * GameManager.instance.speed * Time.deltaTime);
        }
    }

    public void NewPosition()
    {
        GameObject newRoad = roads[0];
        roads.Remove(newRoad);

        float newZ = roads[roads.Count-1].transform.position.z + offset;
        newRoad.transform.position = new Vector3(0, 0, newZ);
        
        roads.Add(newRoad);
    }

    public void Increase()
    {
        if(count < maxCount)
        {
           // GameManager.instance.speed += Util.IncreaseValue(count++);
        }
    }
}