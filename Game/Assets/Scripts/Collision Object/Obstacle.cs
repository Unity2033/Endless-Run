using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IHitable
{
    public void Activate()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (State.Ready == false) return;

        transform.Translate(Vector3.back * SpeedManager.instance.Speed * Time.deltaTime);
    }
}