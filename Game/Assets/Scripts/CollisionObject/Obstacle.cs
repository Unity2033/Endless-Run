using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : State, IHitable
{
    [SerializeField] float speed;

    [SerializeField] Vector3 direction;
    [SerializeField] Sound sound = new Sound();

    public float Speed
    {
        set { speed = value; }
        get { return speed; }
    }

    public void Activate()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        base.OnEnable();
  
        direction = Vector3.forward;

        speed = Random.Range(SpeedManager.Speed, SpeedManager.Speed + 5);
    }

    void Update()
    {
        if (state == false) return;

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
