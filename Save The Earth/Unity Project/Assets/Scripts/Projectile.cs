using UnityEngine;

// bullets : deal damage on impact, get destroyed afterwards
public class Projectile : MonoBehaviour, IProjectile
{
    [SerializeField] float _damage;
    public float Damage { get => _damage; }
    // GameObject DestructionPrefab;
    protected Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(this.GetType().ToString() + " hit: Object deactivated");
        // destuction animation
        // Deactivate();
    }

    public void Activate(Vector3 pos)
    {
        gameObject.SetActive(true);
        transform.position = pos;
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

public interface IProjectile
{
    float Damage { get; }
    void Deactivate();
}
