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
    Collider2D _leftTrigger;
    public Collider2D leftTrigger { get { return _leftTrigger; } set { _leftTrigger = value; } }
    [HideInInspector]
    Collider2D _rightTrigger;
    public Collider2D rightTrigger { get { return _rightTrigger; } set { _rightTrigger = value; } }
    [HideInInspector]
    Collider2D _bottomTrigger;
    public Collider2D bottomTrigger
    {
        get { return _bottomTrigger; }
        set
        {
            _bottomTrigger = value;
            if (_bottomTrigger.gameObject.tag == "Ground")
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }
    }
    //[HideInInspector]
    //public Collider2D topTrigger { get; set; }*/

    bool grounded;
    public bool _grounded
    {
        get { return grounded; }
        set { grounded = value; }
    }
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
        //grounded = true ? bottomTrigger.gameObject.tag == "Ground" : false;

        //ani.SetBool("Grounded", grounded);

        HorizontalMovement();
        Jump();

        
        //print("grounded: " + grounded);
        //print("hasBeen: " + hasBeenGrounded);
        //print("input: " + Input.GetButtonDown("Vertical"));
        //print("Player: " + rb.transform.position);
        //print("Camera: " + GameObject.Find("Main Camera").transform.position);
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
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //ani.SetBool("Jumping", true);
            //print("Jump: " + rb.velocity.y);
        }
    }
}
