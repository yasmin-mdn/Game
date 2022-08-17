using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : Destructible
{
    public HealthBar healthBar;
    void Start()
    {
        friendlyFire = false;
        healthBar.SetMaxValue(this.life);
    }
    public override void OnDestruction()
    {
        // Debug.Log("Planet Destroyed! GAME OVER");
        // emit event ?
        EventSystemCustom.Instance.OnGameOver.Invoke();
        // UnityEditor.EditorApplication.isPlaying = false;
    }

    public override void TakeDamage()
    {
        healthBar.SetValue(this.life);
    }

    public override void AnimateDestruction()
    {
       
    }
}
