using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectScoreManager : MonoBehaviour
{
    public Text mangertext;
    public void Setup(float score)
    {
        mangertext.text = " + "+score.ToString();
        gameObject.SetActive(true);
        StartCoroutine(HideAfterAnounce());
    }

    IEnumerator HideAfterAnounce()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

}
