using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    DinoController dino;
    public GameObject obj;
    public ImgBg ImgBg;
    // Start is called before the first frame update
    void Start()
    {
        dino = obj.GetComponent<DinoController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Quad1" )
        {
            Time.timeScale = 0;
            ImgBg.setup();
            Debug.Log("Final Score: " + dino.Score);
        }

        if(collider.name == "ComboMaker1")
        {
            if (collider.tag=="HeartCombo")
            {
                
                ////changes for score here
                dino.Score += 50;
                Debug.Log("HeartCombo---Score: "+dino.Score);

            }

            if (collider.tag == "BulletCombo")
            {
                ////changes for bullet here
                dino.BulletCount += 1;
                Debug.Log("BulletCombo---BulletCount: "+dino.BulletCount);
            }

            Destroy(collider.gameObject);
        }
        

    }
    }
