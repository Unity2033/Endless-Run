using UnityEngine;

public interface IItem
{
    public void Use(Runner runner);
}

public interface IObstacleCollision
{
    public void Activate(GameObject obstacle);
    
}

