using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Score;
    public Text Bullets;
    DinoController dino;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        dino = obj.GetComponent<DinoController>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = dino.Score.ToString();
        Bullets.text = dino.BulletCount.ToString();
    }
}
