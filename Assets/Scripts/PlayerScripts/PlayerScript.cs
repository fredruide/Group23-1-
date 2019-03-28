using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator ani;
    Camera mainCam;

    bool grounded;
    public bool _grounded
    {
        get { return grounded; }
        set { grounded = value; }
    }
    bool directionFaced;
    public bool _directionFaced
    {
        get { return directionFaced; }
    }

    #region IDEvariabler
    public float speed;
    public float jump;
    public float coyoteCD;
    #endregion
    float coyoteTS;
    public float _coyoteTS
    {
        set { coyoteTS = value + coyoteCD; }
    }
    #region StatsVariabler
    int health;
    int maxHealth;
    Vector2 respawnPosition;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();

        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //grounded = true ? bottomTrigger.gameObject.tag == "Ground" : false;

        //ani.SetBool("Grounded", grounded);

        HorizontalMovement();
        Jump();

        GetComponentInChildren<SpriteRenderer>().flipX = true;

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

    bool hasJumped;

    void Jump()
    {
        //print(Input.GetButtonDown("Vertical"));
        if (grounded == true && Input.GetButtonDown("Vertical"))
        {
            hasJumped = true;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //ani.SetBool("Jumping", true);
            //print("Jump: " + rb.velocity.y);
        }
        else if (!grounded && Input.GetButtonDown("Vertical") && coyoteTS >= Time.time)
        {
            hasJumped = true;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //ani.SetBool("Jumping", true);
            //print("Jump: " + rb.velocity.y);
        }

        if (grounded)
            hasJumped = false;
    }

    bool hasDoubleJumped;

    void DoubleJump()
    {
        if (!grounded && Input.GetButtonDown("Vertical") && !hasDoubleJumped && coyoteTS < Time.time)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = new Vector2(rb.velocity.x, jump);
            hasDoubleJumped = true;
        }

        if (grounded)
            hasDoubleJumped = false;
    }

    #region StatManipulators
    void TakeDamage(int dmg)
    {
        if (dmg >= health)
            Die();
        else
            health -= dmg;
    }

    void Die()
    {
        rb.transform.position = respawnPosition;
    }

    void Heal(int heal)
    {
        if (heal + health > maxHealth)
            health = maxHealth;
        else
            health += heal;
    }

    void SetRespawn(Vector2 newRespawn)
    {
        respawnPosition = newRespawn;
    }
    #endregion
}
