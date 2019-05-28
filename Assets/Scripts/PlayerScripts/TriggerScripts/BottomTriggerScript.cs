using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomTriggerScript : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerScript ps;

    //bool and float for coyote time.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
<<<<<<< HEAD
            ps._isGrounded = true;
=======
            ps._grounded = true;
            Debug.Log("Landed");
            FindObjectOfType<AudioManager>().Play("Land");
>>>>>>> e464e321e71fc47174e55194eeee6a829118e362
            //print("BottomScript Enter hit: " + collision.gameObject.tag);
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" )
        {
            //print("BottomScript Stay hit: " + collision.gameObject.name);
            ps._isGrounded = true;
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            ps._isGrounded = false;
            ps._coyoteTS = Time.time;
            //print("BottomScript Exit hit: " + collision.gameObject.tag);
        }   
        //
    }
}
