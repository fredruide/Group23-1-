using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator ani;
    /*
    [HideInInspector]
    public Collider2D leftTrigger;
    [HideInInspector]
    public Collider2D rightTrigger;
    [HideInInspector]
    public Collider2D bottomTrigger;
    [HideInInspector]
    public Collider2D topTrigger;
    */
    [HideInInspector]
    public bool leftTrigger;
    [HideInInspector]
    public bool rightTrigger;
    [HideInInspector]
    public bool bottomTrigger;
    [HideInInspector]
    public bool topTrigger;

    bool grounded;
    bool hasBeenGrounded;

    #region IDEvariabler
    public float speed;
    public float jump;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = true ? bottomTrigger : false;

        //ani.SetBool("Grounded", grounded);

        HorizontalMovement();
        Jump();

        //print("grounded: " + grounded);
        //print("hasBeen: " + hasBeenGrounded);
        //print("input: " + Input.GetButtonDown("Vertical"));
    }

    void HorizontalMovement()
    {
        if (grounded && Input.GetAxisRaw("Horizontal") != 0)
        {
            rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        }
        else if (!grounded && Input.GetAxisRaw("Horizontal") != 0)
        {
            rb.velocity = new Vector2(speed / 2 * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void Jump()
    {
        if (grounded && Input.GetButtonDown("Vertical"))
        {
            print("jump");
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //ani.SetBool("Jumping", true);
        }
    }
}
