using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassagePanelManager : MonoBehaviour
{
    public Text mangertext;
   public void Setup(string message)
    {
        mangertext.text = message;
        gameObject.SetActive(true);
        StartCoroutine(HideAfterAnounce());
    }

   IEnumerator HideAfterAnounce()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
