using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom:MonoBehaviour
{
    public UnityEvent OnIncreaseHeart;
    public UnityEvent OnDecreaseHeart;
    void Awake()
    {
        OnIncreaseHeart = new UnityEvent();
        OnIncreaseHeart = new UnityEvent();
    }

}