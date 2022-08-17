using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeapon : Weapon
{
    // static Image BulletIcon
    static GameObject SimpleBulletPrefab = Resources.Load("SimpleBullet") as GameObject;
    Vector3 aim, spawnPos;
    IEnumerator shootCoroutine = null;

    public SimpleWeapon(float shootPower, float shootRate) 
    : base(0, shootPower, shootRate, SimpleBulletPrefab)
    {}

    public override void ActivateOnDown(Vector3 aim, Transform target, Vector3 spawnPos)
    {
        if(shootCoroutine == null)
        {
            shootCoroutine = ShootCoroutine();
            CoroutineHelper.Instance.StartCoroutine(shootCoroutine);
        }
    }

    public override void ActivateOnHold(Vector3 aim, Transform target, Vector3 spawnPos)
    {
        this.aim = aim;
        this.spawnPos = spawnPos;
    }

    public override void DeactivateOnHold()
    {
        // nothing
    }

    public override void DeactivateOnUp()
    {
        if(shootCoroutine != null)
        {
            CoroutineHelper.Instance.StopCoroutine(shootCoroutine);
            shootCoroutine = null;
        }
    }

    IEnumerator ShootCoroutine()
    {
        while(true)
        {
            var obj = GameObject.Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
            var bullet = obj.GetComponent<SimpleBullet>();
            bullet.ShootAt(aim, shootPower);
            yield return new WaitForSeconds(1f / shootRate);
        }
    }
}
