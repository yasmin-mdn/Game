using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Projectile, IProjectile
{
    public void ShootAt(Vector3 aim, float shootPower)
    {
        var direction = aim - transform.position;
        direction.Normalize();
        rb.AddForce(direction * shootPower, ForceMode.Impulse);
    }
}
