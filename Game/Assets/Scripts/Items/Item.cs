using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 150.0f;
    [SerializeField] protected ParticleSystem particle;

    protected virtual void Update()
    {        
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    protected void Effect()
    {
        particle.Play();
    }
    
}
