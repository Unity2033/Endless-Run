using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Condition
{
    START,
    FINISH,
    RESUME
}

public static class State
{
    private static Action start;
    private static Action finish;
    private static Action resume;

    public static void Subscribe(Condition condition, Action unityAction)
    {
        switch (condition)
        {
            case Condition.START  : start += unityAction;
                break;
            case Condition.FINISH : finish += unityAction;
                break;
            case Condition.RESUME : resume += unityAction;
                break;
        }
    }

    public static void Unsubscribe(Condition condition, Action unityAction)
    {
        switch (condition)
        {
            case Condition.START  : start -= unityAction;
                break;
            case Condition.FINISH : finish -= unityAction;
                break;
            case Condition.RESUME : resume -= unityAction;
                break;
        }
    }


    public static void Publish(Condition condition)
    {
        switch (condition)
        {
            case Condition.START  :  start?.Invoke();
                break;
            case Condition.FINISH : finish?.Invoke();
                break;
            case Condition.RESUME : resume?.Invoke();
                break;
        }
    }
}