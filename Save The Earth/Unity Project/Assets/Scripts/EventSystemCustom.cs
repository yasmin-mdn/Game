using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



[System.Serializable]
public class MyfloatEvent : UnityEvent<float>
{
}

public class MyStringEvent : UnityEvent<string>
{
}
public sealed class EventSystemCustom
{
    public MyfloatEvent OnIncreaseScore;
    public UnityEvent OnGameOver;
    public MyStringEvent OnMessage;
    public MyfloatEvent OnWeaponChange;
    public MyfloatEvent OnTimerChange;

    private static readonly EventSystemCustom instance = new EventSystemCustom();
    
    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static EventSystemCustom()
    {
    }

    private EventSystemCustom()
    {
       OnIncreaseScore = new MyfloatEvent();
        OnGameOver = new UnityEvent ();
        OnMessage = new MyStringEvent();
        OnWeaponChange = new MyfloatEvent();
        OnTimerChange= new MyfloatEvent();
    }

    public static EventSystemCustom Instance
    {
        get
        {
            return instance;
        }
    }
}