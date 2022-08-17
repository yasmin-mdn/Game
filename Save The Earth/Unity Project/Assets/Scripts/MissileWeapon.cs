using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileWeapon : Weapon
{
    // static Image MissileIcon
    static GameObject MissilePrefab = Resources.Load("Missile (Launched)") as GameObject;
    static int INITIAL_AMMO_COUNT = 5;
    public MissileWeapon() : base(INITIAL_AMMO_COUNT, 0, 0, MissilePrefab) {}
    bool shootNext = true;

    public override void ActivateOnDown(Vector3 aim, Transform target, Vector3 spawnPos)
    {
        if(target == null)
        {
            // Debug.Log("MissileWeapon: Target not locked");
            return;
        }
        if(ammoCount == 0)
        {
            // Debug.Log("MissileWeapon: No Ammo");
            return;
        }

        UseAmmo();
        var obj = GameObject.Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        var bullet = obj.GetComponent<Missile>();
        bullet.LockOn(target);
    }

    IEnumerator ShootTimer()
    {
        shootNext = false;
        yield return new WaitForSeconds(1f);
        shootNext = true;
    }

    public override void ActivateOnHold(Vector3 aim, Transform target, Vector3 spawnPos)
    {
        // nothing
    }

    public override void DeactivateOnHold()
    {
        // nothing
    }

    public override void DeactivateOnUp()
    {
        // nothing
    }
}
