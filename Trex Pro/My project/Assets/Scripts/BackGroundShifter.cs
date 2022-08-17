using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundShifter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        float Width = ((BoxCollider2D)collider).size.x;
        Vector3 pos = collider.transform.position;
        pos.x += Width * 1.95f;
        if (collider.gameObject.tag == "BG1")
        {
            collider.transform.position = pos;
        }
        if (collider.gameObject.tag == "BG2")
        {
            collider.transform.position = pos;
        }

    }
}
