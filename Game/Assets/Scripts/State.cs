using System;

public static class State
{
    private static bool ready;

    public static bool Ready { get { return ready; }  set { ready = value; } }

    public static Action OnResume;
    public static Action OnFinish;
    public static Action OnExecute;
}
