using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    List<(GameObject,GameObject)> targets = new List<(GameObject,GameObject)>(); // (real target body, corresponding indicator target) 
    [SerializeField] GameObject indicatorTargetPrefab;
    
    void Update()
    {
        // Debug.Log("targets count: " + targets.Count);
        for (int i = 0; i < targets.Count; i++)
        {
            var (rt, it) = targets[i];
            if(!rt.activeInHierarchy)
            {
                it.SetActive(false);
                targets.RemoveAt(i);
                i--;
                continue;
            }
            UpdateIndicator(rt, it);
        }
    }

    void UpdateIndicator(GameObject rt, GameObject it)
    {
        var vect = rt.transform.position - transform.position;
        var vect2 = Vector3.ProjectOnPlane(vect, -transform.forward);
        vect2.Normalize();
        vect2 *= vect.magnitude;
        it.transform.LookAt(it.transform.position + vect2, transform.forward);
    }

    public bool TryAddTarget(GameObject target)
    {
        if(!target.CompareTag("SpaceShip") || !target.activeInHierarchy)
            return false;
        var it = Instantiate(indicatorTargetPrefab, transform);
        targets.Add((target.transform.Find("Body").gameObject, it));
        return true;
    }

    (float, float) GetObjectRotation(GameObject obj) => (obj.transform.rotation.x, obj.transform.rotation.z);
}
