using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneMove : MonoBehaviour
{
    public bool isMovingSameDirection;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    private bool canJump;
    private bool canMove;
    //public Text counterText; // Too dirty!

    public EventSystemCustom eventSystem;

    private void Awake()
    {
        canJump = true;
        canMove = true;
    }
    public void Move(Vector3 vec, bool isDirRight)
    {
        if (!canMove)
            return;

        int factor = 1;
        if (isDirRight)
        {
            if (isMovingSameDirection)
            {
                spriteRenderer.flipX = false;
                factor = 1;
            }
            else
            {
                spriteRenderer.flipX = true;
                factor = -1;
            }
        }
        else
        {

            if (isMovingSameDirection)
            {
                spriteRenderer.flipX = true;
                factor = -1;
            }
            else
            {
                spriteRenderer.flipX = false;
                factor = 1;

            }
        }

        transform.position += vec * factor;
    }

    public void Jump(float amount)
    {
        if (canJump)
            rb.AddForce(transform.up * amount, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.Log("sticky for clone");


            // This is used by UiManager
            eventSystem.OnCloneStickyPlatformEnter.Invoke();
            Debug.Log("OnCloneStickyPlatformEnter fired.");

            canJump = false;
            canMove = false;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    { 
    if (collision.gameObject.CompareTag(TagNames.teleportDoor.ToString()))
        {
            //TeleportDoor=collision.gameObject;
            Debug.Log("Teleport clone!!");
            transform.position = collision.GetComponent<teleDoor>().Dest.transform.position;
        }
    }



        private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagNames.StickyPlatform.ToString()))
        {
            Debug.Log("sticky no more for clone bruh");
            canJump = true;
        }
    }
}
