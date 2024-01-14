using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : CollisionObject
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

    public override void Activate(Runner runner)
    {
        runner.animator.Play("Die");

        AudioManager.instance.Sound(sound.clips[0]);

        gameObject.GetComponent<AudioSource>().mute = true;

        GameManager.instance.GameOver();
    }
}
