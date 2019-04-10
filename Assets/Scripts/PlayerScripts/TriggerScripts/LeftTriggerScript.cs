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
        if (collision.gameObject.tag == "Platform")
        {
            ps._touchLeft = true;
        }
        if (collision.gameObject.tag == "Platform")
        {
            ps._canWallSlide = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            ps._touchLeft = true;
        }
        if (Input.GetButtonDown("Vertical") && collision.gameObject.tag == "Platform")
        {
            ps._canWallSlide = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            ps._touchLeft = false;
        }
        if (collision.gameObject.tag == "Platform")
        {
            ps._canWallSlide = false;
        }
    }
}
