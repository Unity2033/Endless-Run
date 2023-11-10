using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 150.0f;
    [SerializeField] protected ParticleSystem particle;

    void Update()
    {        
        transform.Translate(Vector3.down * GameManager.instance.speed * Time.deltaTime);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime*0);
    }

    protected void Effect()
    {
        particle.Play();
    }
    
}
