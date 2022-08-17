using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public Text mangertext;
    public void Setup(float time)
    {
        gameObject.SetActive(true);
        if (time >= 0)
        {
            mangertext.text = time.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }

   
}
