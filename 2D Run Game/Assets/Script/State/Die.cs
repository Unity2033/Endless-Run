using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : IState
{
    public void Action(Animator animator, Rigidbody2D rigidBody)
    {
        animator.Play("Die");

        rigidBody.gravityScale = 0.0f;
    }
}
