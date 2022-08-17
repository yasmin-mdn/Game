using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject parent;
    void Awake()
    {
        parent = transform.parent.gameObject;
    }

    void OnCollisionEnter(Collision collision)
    {
        parent.SendMessage("OnCollisionEnter", collision);
    }
}
