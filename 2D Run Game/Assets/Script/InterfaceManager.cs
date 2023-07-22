using UnityEngine;

public interface IState
{
    void Action(Animator animator, Rigidbody2D rigidBody);
}


