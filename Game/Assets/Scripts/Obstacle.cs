using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacleCollision
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
        
        StartCoroutine(Stop());

        speed = other.speed;
    }

    public IEnumerator Stop()
    {
        speed = 0;

        yield return CoroutineCache.waitForSeconds(2.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        IObstacleCollision obstacleCollision = other.GetComponent<IObstacleCollision>();

        if (obstacleCollision != null)
        {
            obstacleCollision.Activate(gameObject);
        }
    }
}
