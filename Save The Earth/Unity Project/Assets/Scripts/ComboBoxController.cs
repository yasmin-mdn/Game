using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboBoxController : MonoBehaviour, ISpawnable
{
    public float MinHeight { get => 58; }
    public float MaxHeight { get => 63; }
    Rigidbody bodyRb;
    Transform bodyTr;
    [SerializeField] float fallSpeed;
    float MoveDownward { get => Time.fixedDeltaTime * fallSpeed; }
    bool gravitate;
    public ICombo Combo { get; private set; }
    void Start()
    {
        bodyTr = transform.Find("Body");
        bodyRb = bodyTr.GetComponent<Rigidbody>();
        gravitate = true;
        Combo = RandomCombo();
       
    }

    void FixedUpdate()
    {
        if(gravitate)
            bodyRb.MovePosition(bodyRb.position - bodyTr.up * MoveDownward);
    }

    void OnCollisionEnter(Collision collision)
    {
        gravitate = false;
    }
    void OnCollisionExit(Collision collision)
    {
        gravitate = true;
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    ICombo RandomCombo()
    {
        var rand = UnityEngine.Random.Range(0, 4);
        switch (rand)
        {
            case 0: return new EarthShieldCombo();
            case 1: return new HealthIncreaseCombo();
            case 2: return new MissileWeapon();
            case 3: return new TurboRefillCombo();
            default: return null;
        }
    }
}
