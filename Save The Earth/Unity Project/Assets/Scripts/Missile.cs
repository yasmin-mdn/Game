using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile
{
    [SerializeField] float moveSpeed;
    float MoveAmount { get => Time.fixedDeltaTime * moveSpeed; }
    Transform target;
    bool isLocked = false;
    
    void FixedUpdate()
    {
        if(isLocked)
        {
            if(target != null && target.gameObject.activeInHierarchy) {
                transform.LookAt(target);
                transform.Rotate(0, -90f, 0);
            }
            rb.MovePosition(rb.position + transform.right * MoveAmount);
        }
    }

    public void LockOn(Transform target)
    {
        // if(target == null)
        // {
        //     // Debug.Log("Missile: Target not locked");
        //     Deactivate();
        //     return;
        // }
        this.target = target;
        isLocked = true;
    }
}
