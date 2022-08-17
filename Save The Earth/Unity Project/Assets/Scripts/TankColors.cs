using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TankColors : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    void Start()
    {
        var tankColor = GameObject.Find("AudioManager").GetComponent<AudioManager>().tankColor;
        buttons[(int)tankColor].onClick.Invoke();
    }
    public void SetTankColor(string tankColorName)
    {
        var tankColor = (TankColor)Enum.Parse(typeof(TankColor), tankColorName);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().tankColor = tankColor;
    }

    public void SetBackgroundVolume(System.Single volume)
    {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().SetBackgroundVolume(volume);
    }
}
