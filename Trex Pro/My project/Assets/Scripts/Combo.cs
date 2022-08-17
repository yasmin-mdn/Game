using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public GameObject[] ob;
    public Transform camPos;
    
    // Start is called before the first frame update
    void Start()
    {
        ComboeMaker();
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * PlayerPrefs.GetInt("speed") * Time.deltaTime);
        GameObject cs = GameObject.Find("ComboMaker1");
        if(cs != null)
        {
            if (camPos.position.x - cs.transform.position.x > 25)
            {
                Destroy(cs);
            }
        }
       
    }

    void ComboeMaker()
    {
        var rand = Random.Range(0, ob.Length);
        GameObject clone = (GameObject)Instantiate(ob[rand], transform.position, Quaternion.identity);
        clone.name = "ComboMaker1";
        clone.AddComponent<BoxCollider2D>();
        clone.GetComponent<BoxCollider2D>().isTrigger = true;
        float xx = Random.Range(0, 20);
        Invoke("ComboeMaker", xx);

    }
}
