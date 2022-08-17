using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text clonecounterText;
    public Text KeyCounterText;
    public EventSystemCustom eventSystem;

    void Start()
    { 
        eventSystem.OnCloneStickyPlatformEnter.AddListener(delegate{UpdateScoreText();});
        eventSystem.OnCollectKey.AddListener(delegate{UpdateKeyCountText();});
    }

    public void UpdateScoreText()
    {
        Debug.Log("UPDATE SCORE");
        var newTextValue = int.Parse(clonecounterText.text) + 1;
            clonecounterText.text = newTextValue.ToString();
    }
    public void UpdateKeyCountText()
    {
        Debug.Log("UPDATE KeyCount");
        var newTextValue = int.Parse(KeyCounterText.text) + 1;
            KeyCounterText.text = newTextValue.ToString();
    }
}
