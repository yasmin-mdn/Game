using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public Text text;

 
    public void Setup(float count)
    {
        text.text = count.ToString();
    }
}
