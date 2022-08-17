using System.Collections;
using UnityEngine;

// object with a life
public abstract class Destructible : MonoBehaviour
{
    protected bool friendlyFire = true;
    public float life;
    public float MaxLife { get; private set; }
    public float Score;
   // public GameObject ExplosionEffect;

    void Awake()
    {
        MaxLife = life;
    }

    public virtual void  OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            IProjectile projectile = collision.gameObject.GetComponent<IProjectile>();
            if(projectile == null) projectile = collision.gameObject.GetComponentInParent<IProjectile>();
            if(friendlyFire || (collision.gameObject.name != "SimpleBullet(Clone)" && collision.gameObject.name != "Missile (Launched)(Clone)"))
            {
                // Debug.Log(this.GetType().ToString() + " got hit: -" + projectile.Damage.ToString());
                AddLife(-projectile.Damage);
            }
            projectile.Deactivate();
        }
    }

    public void AddLife(float life)
    {
        this.life += life;
        if(this.life > MaxLife) this.life = MaxLife;
        TakeDamage();
        // emit event
        CheckLife();
    }

    void CheckLife()
    {
        if (life <= 0f)
        {
            // Debug.Log(this.GetType().ToString() + " life zero: Object deactivated");
            AnimateDestruction();
            OnDestruction();

            // emit event
            gameObject.SetActive(false);



        }
    }
    public virtual void OnDestruction()
    {
        EventSystemCustom.Instance.OnIncreaseScore.Invoke(Score);
    }

    public abstract void TakeDamage();
    public abstract void AnimateDestruction();
    //public void AnimateDestruction() {

    //    Instantiate(ExplosionEffect, this.transform.position,this.transform.rotation);
    //}



}
