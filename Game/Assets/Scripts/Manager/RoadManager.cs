using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] bool state = true;
    [SerializeField] float offset = 40.0f;
    [SerializeField] List<GameObject> roads;

    [SerializeField] float speed = 20;

    public void Start()
    {
        roads.Capacity = 10;
    }
    private void Execute()
    {
        state = true;
    }

    private void Stop()
    {
        state = false;
    }

    private void OnEnable()
    {
        EventManager.Susbscribe(EventType.START, Execute);
        EventManager.Susbscribe(EventType.STOP, Stop);
    }

    void Update()
    {
        if (state == false) return;

        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
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

    private void OnDisable()
    {
        EventManager.Unsubscribe(EventType.START, Execute);
        EventManager.Unsubscribe(EventType.STOP, Stop);
    }
}
