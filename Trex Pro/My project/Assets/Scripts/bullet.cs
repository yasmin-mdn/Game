using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    GameObject obj;
    public float bulletspeed = 0.05f;
    public Rigidbody2D rb;
    DinoController dino;
    
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Dino");
        if(obj != null)
        {
            dino = obj.GetComponent<DinoController>();
        }
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * PlayerPrefs.GetInt("speed") * Time.deltaTime  + transform.right * bulletspeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cactus")
        {
            dino.Score += 10;
            Debug.Log("Score: " + dino.Score);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Land")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Rock")
        {
            Destroy(gameObject);
        }

    }


}
