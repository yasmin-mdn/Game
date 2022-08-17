using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDecreaserComboController : ComboInstanceController
{
    GameObject obj;
    private void Start()
    {
        obj = GameObject.Find("Player");
    }
    public override void OnConsume()
    {

        PlayerController player = obj.GetComponent<PlayerController>();
        Debug.Log("Heart Decrease ON CONSUME");
        player.playerHeartsCount -= 1;
    }
}