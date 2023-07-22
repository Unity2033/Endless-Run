using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Character : MonoBehaviour
{
    private bool flag = false;

    private Animator animator;
    private Rigidbody2D rigidBody;

    private IState state = null;

    private void SwitchState(IState state)
    {
        this.state = state;
        this.state.Action(animator, rigidBody);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        SwitchState(new Run());
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {       
            flag = true;
        }
    }

    private void FixedUpdate()
    {
        if(flag == true)
        {
            SwitchState(new Jump());

            flag = false;     
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Death Zone"))
        {
            SwitchState(new Die());
        }
    }
}
