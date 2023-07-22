using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : IState
{
    float power = 250.0f;

    public void Action(Animator animator, Rigidbody2D rigidBody)
    {
        animator.SetBool("Jump", true);

        rigidBody.AddForce
        (
           Vector2.up * power * Time.fixedDeltaTime,
           ForceMode2D.Impulse
        );
    }
}
