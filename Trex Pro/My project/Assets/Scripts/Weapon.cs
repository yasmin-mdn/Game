using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    DinoController dino;
    public GameObject obj;

    void Start()
    {
        dino = obj.GetComponent<DinoController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && dino.BulletCount>0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        dino.BulletCount -= 1;
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Debug.Log("Remain Bullets: " + dino.BulletCount);

    }
}
