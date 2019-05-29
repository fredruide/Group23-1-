using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTriggerScript : MonoBehaviour
{
    //Rigidbody2D rb;
    PlayerScript ps;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        ps = GetComponentInParent<PlayerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Wall")
        {
            ps._touchLeft = true;
        }
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Wall")
        {
            ps._canWallSlide = true;
        }
        //print("lefttrigger =" + collision.gameObject.name);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Wall")
        {
            ps._touchLeft = true;
        }

        if (Input.GetButtonDown("Vertical") && collision.gameObject.tag == "Wall")
        {
            ps._canWallSlide = false;
            ps._isWallSliding = false;
        }
        else if (!Input.GetButtonDown("Vertical") && collision.gameObject.tag == "Wall")
        {
            ps._canWallSlide = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Platform")
        {
            ps._touchLeft = false;
        }
        if (collision.gameObject.tag == "Wall")
        {
            ps._canWallSlide = false;
            ps._isWallSliding = false;

            //Dette er for at sætte proseccen af bools setter i animatoren igang som bliver startet når _isGrounded bliver sat til false
            if (!ps._isGrounded)
            {
                ps._isGrounded = false;
            }                
        }
    }
}
