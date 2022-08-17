using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShieldController : MonoBehaviour
{
    [SerializeField] float timer;
    float currentTimer;
    
    void Awake()
    {
        EarthShieldCombo.EarthShield = gameObject;
        gameObject.SetActive(false);
    }
    void OnEnable()
    {
        currentTimer = timer;
    }
    void Update()
    {
        currentTimer -= Time.deltaTime;
        if(currentTimer <= 0)
            gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            if(collision.gameObject.name == "SimpleBullet") return;
            IProjectile projectile = collision.gameObject.GetComponent<IProjectile>();
            if(projectile == null) projectile = collision.gameObject.GetComponentInParent<IProjectile>();
            // Debug.Log("Shield got hit by " + projectile.GetType().ToString());
            projectile.Deactivate();
        }
    }
}
