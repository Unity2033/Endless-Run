using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Obstacle : CollisionObject, IObstacleCollision
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    private void OnEnable()
    {
        direction = Vector3.forward;
        speed = GameManager.instance.speed + Random.Range(5, 25);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void Activate(GameObject obstacle)
    {
        Obstacle other = obstacle.GetComponent<Obstacle>();
        
        speed = other.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        IObstacleCollision obstacleCollision = other.GetComponent<IObstacleCollision>();

        if (obstacleCollision != null)
        {
            obstacleCollision.Activate(gameObject);
        }
    }

    public override void Activate(Runner runner)
    {
        // runner.OnDeath();
        // 
        // gameObject.GetComponent<AudioSource>().mute = true;
        // 
        // Instantiate(Resources.Load<GameObject>("Death Screen"), GameObject.Find("UI Canvas").transform);
        // 
        // GameManager.instance.GameOver();
    }
}
