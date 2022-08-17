using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnCloneStickyPlatformEnter;
    public UnityEvent OnCollectKey;

    void Awake()
    {
        OnCloneStickyPlatformEnter = new UnityEvent();
        OnCollectKey = new UnityEvent();
    }
}
