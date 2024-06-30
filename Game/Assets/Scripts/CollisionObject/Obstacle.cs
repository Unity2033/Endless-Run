using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour, IHitable
{
    [SerializeField] float speed;
    [SerializeField] bool state = true;

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

        direction = Vector3.forward;
        speed = Random.Range(20, 30);
    }

    void Update()
    {
        if (state == false) return;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(EventType.START, Execute);
        EventManager.Unsubscribe(EventType.STOP , Stop);
    }
}
