using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public bool jumpTrue;
    public bool dashTrue;
    private Rigidbody2D rb2b;
    public Animator animator;

    //TODO sprites klipper over hinanden når falder ned på det sidste koordinat

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            jumpTrue = true;
            animator.SetBool("HasLanded", true);
            animator.SetBool("isFalling", false);
        }
        //if (collision.gameObject.tag == "Platform")
        //{
        //    animator.SetBool("isFalling", false);

        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            jumpTrue = false;            
            animator.SetBool("isFalling", true);
            animator.SetBool("HasLanded", false);
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            dashTrue = true;
        }
    }
    
    // Probably the the place for this function
    public void Falling(Vector2 velocity)
    { 
        if (velocity.y < 0)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }
        else if (velocity.y > 0)
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("HasLanded", false);            
        }
    }

    public bool JumpTest()
    {
        return jumpTrue;
    }

    public bool DashTest()
    {        
        return dashTrue;
    }
}