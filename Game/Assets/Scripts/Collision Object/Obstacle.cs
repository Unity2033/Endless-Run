using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public void Activate(Runner runner)
    {
        runner.Die();
    }
}
