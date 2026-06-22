using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 0.0f;

    private void Update()
    {
        if (GameManager.instance.State == false) return;

        transform.Translate(Vector3.forward * GameManager.instance.Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interact Zone"))
        {
            gameObject.SetActive(false);
        }
    }
}