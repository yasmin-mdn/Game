using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIncreaserComboController : ComboInstanceController
{
    GameObject obj;
    private void Start()
    {
        obj = GameObject.Find("Player");
    }
    public override void OnConsume()
    {
        PlayerController player = obj.GetComponent<PlayerController>();
        Debug.Log("Heart Increase ON CONSUME");
        player.playerHeartsCount += 1;
    }

}
