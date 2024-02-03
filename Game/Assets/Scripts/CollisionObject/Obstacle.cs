using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] Vector3 direction;
    [SerializeField] Sound sound = new Sound();

    public float Speed
    {
        set { speed = value; }
        get { return speed; }
    }

    private void OnEnable()
    {
        direction = Vector3.forward;

        speed = GameManager.instance.speed + Random.Range(10, 20);
    }

    void Update()
    {
        if (GameManager.instance.state == false) return;

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
