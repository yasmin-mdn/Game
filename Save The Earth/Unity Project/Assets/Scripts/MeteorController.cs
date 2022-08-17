using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : Destructible, IProjectile, ISpawnable
{
    [SerializeField] float forwardSpeed, fallSpeed;
    float MoveForward { get => Time.fixedDeltaTime * forwardSpeed; }
    float MoveDownward { get => Time.fixedDeltaTime * fallSpeed; }
    [SerializeField] float _damage;
    public float Damage { get => _damage; }
    public float MinHeight { get => 180; }
    public float MaxHeight { get => 200; }
    Transform body, visuals;
    Vector3 forwardVector, downwardVector;
    GameObject playerObj;
    public GameObject ExplosionEffect;
    AudioManager audioManager;

    void Start()
    {
        body = transform.Find("Body");
        transform.Rotate(0, UnityEngine.Random.Range(0, 360), 0);
        forwardVector = new Vector3(1f, 0, 0);
        downwardVector = new Vector3(0, -1f);
        audioManager = FindObjectOfType<AudioManager>();

    }
    void FixedUpdate()
    {
        body.Translate(downwardVector * MoveDownward);
        transform.Rotate(forwardVector * MoveForward);
    }



    public void Deactivate()
    {
        AnimateDestruction();
        gameObject.SetActive(false);
    }

    public override void TakeDamage()
    {

    }

    public override void AnimateDestruction()
    {
        Instantiate(ExplosionEffect, this.body.position, this.body.rotation);
        if (audioManager != null)
        {
            audioManager.Play("MeteorDestruction");
        }
        StartCoroutine(DistroyEffect());
    }

    IEnumerator DistroyEffect()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(ExplosionEffect);
    }
}
