public class FrontDetector : CollisionObject
{
    public override void Activate(Runner runner)
    {
        EventManager.Publish(EventType.STOP);

        runner.Die();
    }
}