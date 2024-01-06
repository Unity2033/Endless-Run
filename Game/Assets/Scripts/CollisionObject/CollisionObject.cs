using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionObject : MonoBehaviour
{
    public abstract void Activate(Runner runner);
}
