using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : Destructible, ISpawnable
{
    public float MinHeight { get => 58; }
    public float MaxHeight { get => 63; }
    [SerializeField] float moveSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float shootPower;
    [SerializeField] float shootRate;
    float MoveAmount { get => Time.deltaTime * moveSpeed; }
    float RotationAmount { get => Time.deltaTime * rotationSpeed; }
    public GameObject bulletPrefab;
    [SerializeField] Transform spawnPoint;
    Transform body;
    Rigidbody rb;
    public GameObject ExplosionEffect;
    AudioManager audioManager;


    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        body = transform.Find("Body");
        StartCoroutine(ShootCoroutine());
        StartCoroutine(RandGenCoroutine());
        audioManager = FindObjectOfType<AudioManager>();
       
       
    }

    void Update()
    {
        RandomMove();
    }

    float rand1, rand2, rand3;
    private void RandomMove()
    {
        var verticalMovement = rand1 * MoveAmount;
        var horizontalMovement = rand2 * MoveAmount;
        var rotationMovement = rand3 * RotationAmount;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(-verticalMovement, rotationMovement, horizontalMovement));
    }

    void ShootWeapon()
    {
        var bullet = GameObject.Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        var bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(-body.up * shootPower, ForceMode.Impulse);
       
        
    }

    IEnumerator ShootCoroutine()
    {
        while(true)
        {
            ShootWeapon();
            yield return new WaitForSeconds(1f / shootRate);
        }
    }
    
    IEnumerator RandGenCoroutine()
    {
        while(true)
        {
            rand1 = UnityEngine.Random.Range(-1f, 1f);
            rand2 = UnityEngine.Random.Range(-1f, 1f);
            rand3 = UnityEngine.Random.Range(-1f, 1f);
            yield return new WaitForSeconds(4f);
        }
    }

    public override void TakeDamage()
    {
       
    }

    public override void AnimateDestruction()
    {
        Instantiate(ExplosionEffect, this.body.position, this.body.rotation);
        if (audioManager != null)
        {
            audioManager.Play("SpaceshipDestruction");
        }
        StartCoroutine(DistroyEffect());
    }

    IEnumerator DistroyEffect()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(ExplosionEffect);
    }
}
