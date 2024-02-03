using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleDetector : CollisionObject
{
    public override void Activate(Runner runner)
    {
        runner.RevertPosition();
    }
}
