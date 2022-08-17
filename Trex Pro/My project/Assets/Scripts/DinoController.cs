using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public int Score;
    public int BulletCount;
    public float jumpAmount ;
    public bool isGrounded;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        BulletCount = 5;
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>();
        PlayerPrefs.SetInt("speed", 6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * PlayerPrefs.GetInt("speed") * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump!!");
            Vector3 jumpMovement = new Vector3(0.0f, 1.0f, 0.0f);
            rb.velocity = jumpMovement * jumpAmount;
            isGrounded = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            Debug.Log("isGrounded");
            isGrounded = true;
        }

       

    }
}
