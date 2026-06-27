using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] ObstacleManager obstacleManager;

    public float Speed { set { speed = value; } get { return speed; } }

    private void OnEnable()
    {
        speed = Random.Range(GameManager.instance.Speed, GameManager.instance.Speed + 20f);
    }

    private void Start()
    {
        obstacleManager = GameObject.Find("Obstacle Manager").GetComponent<ObstacleManager>();
    }

    private void Update()
    {
        if (GameManager.instance.State == false) return;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interact Zone"))
        {
            obstacleManager.Return(gameObject);
        }
    }
}