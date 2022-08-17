using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon: ICombo
{
    [SerializeField] protected float ammoCount;
    [SerializeField] protected float shootPower;
    [SerializeField] protected float shootRate;
    protected GameObject projectilePrefab;
    public string Name { get => "Missile Refill"; set => Name = value; }
    
    
    // Image WeaponIcon

    protected Weapon(float ammoCount, float shootPower, float shootRate, GameObject projectilePrefab)
    {
        this.ammoCount = ammoCount;
        this.shootPower = shootPower;
        this.shootRate = shootRate;
        this.projectilePrefab = projectilePrefab;
        
    }
    public abstract void ActivateOnHold(Vector3 aim, Transform target, Vector3 spawnPos);
    public abstract void ActivateOnDown(Vector3 aim, Transform target, Vector3 spawnPos);
    public abstract void DeactivateOnHold();
    public abstract void DeactivateOnUp();
    protected void UseAmmo()
    {
        --ammoCount;
        // emit event update ammo count (Weapon Slot2)
        EventSystemCustom.Instance.OnWeaponChange.Invoke(ammoCount);
    }

    public void ActivateCombo()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().SetWeapon(this);
        EventSystemCustom.Instance.OnWeaponChange.Invoke(ammoCount);
    }
}

class CoroutineHelper : MonoBehaviour
{
    public static CoroutineHelper _Instance;
    public static CoroutineHelper Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new GameObject("CoroutineHelper").AddComponent<CoroutineHelper>();
			}

			return _Instance;
		}
	}
}
