using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : CollisionObject
{
    [SerializeField] float speed;
    [SerializeField] float increaseSpeed;

    [SerializeField] Vector3 direction;

    private void OnEnable()
    {
        direction = Vector3.forward;

        increaseSpeed += 5;

        speed = GameManager.instance.speed + increaseSpeed;
    }

    void Update()
    {
        if (GameManager.instance.state == false) return;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public override void Activate(Runner runner)
    {
        runner.OnDeath();

        gameObject.GetComponent<AudioSource>().mute = true;

        GameManager.instance.GameOver();
    }
}
