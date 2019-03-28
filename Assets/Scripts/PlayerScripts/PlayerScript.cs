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
        set
        {
            grounded = value;
            if (value == true)
            {
                canJumped = true;
                canDoubleJumped = true;
            }
        }
    }
    bool touchRight;
    public bool _touchRight
    {
        get { return touchRight; }
        set { touchRight = value; }
    }
    bool touchLeft;
    public bool _touchLeft
    {
        get { return touchLeft; }
        set { touchLeft = value; }
    }
    //true = facing right : false = facing left
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
    public int health;
    public int maxHealth;
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
        DirectionFacing();
        //grounded = true ? bottomTrigger.gameObject.tag == "Ground" : false;

        //ani.SetBool("Grounded", grounded);

        HorizontalMovement();
        Jump();
        DoubleJump();

        //print("grounded: " + grounded);
        //print("canJumped: " + canJumped);
        //print("hasBeen: " + hasBeenGrounded);
        //print("input: " + Input.GetButtonDown("Vertical"));
        //print("Player: " + rb.transform.position);
        //print("Camera: " + GameObject.Find("Main Camera").transform.position);
    }

    void HorizontalMovement()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if(!touchRight && Input.GetAxisRaw("Horizontal") > 0)
                rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            else if (!touchLeft && Input.GetAxisRaw("Horizontal") < 0)
                rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            else
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
        /*else if (!grounded && Input.GetAxisRaw("Horizontal") != 0)
        {
            if (!touchRight && Input.GetAxisRaw("Horizontal") > 0)
                rb.velocity = new Vector2(speed / 2 * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            else if (!touchLeft && Input.GetAxisRaw("Horizontal") < 0)
                rb.velocity = new Vector2(speed / 2 * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            else
                rb.velocity = new Vector2(0, rb.velocity.y);
        }*/
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        } 
    }

    bool canJumped;

    void Jump()
    {
        //print(Input.GetButtonDown("Vertical"));
        if (grounded == true && Input.GetButtonDown("Vertical"))
        {
            canJumped = false;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //ani.SetBool("Jumping", true);
            print("Jump: " + rb.velocity.y);
            print("grounded: " + grounded);
            print("canJumped: " + canJumped);
        }
        else if (!grounded && Input.GetButtonDown("Vertical") && coyoteTS >= Time.time && canJumped)
        {
            canJumped = false;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //ani.SetBool("Jumping", true);
            print("Jump Coyote: " + rb.velocity.y);
            print("grounded: " + grounded);
            print("canJumped: " + canJumped);
        }
    }

    bool canDoubleJumped;

    void DoubleJump()
    {
        if (!grounded && Input.GetButtonDown("Vertical") && canDoubleJumped && canDoubleJumped)
        {
            canDoubleJumped = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = new Vector2(rb.velocity.x, jump);            
            print("DoubleJump: " + rb.velocity.y);
        }
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
    #region HelperMethods
    void DirectionFacing()
    {
        //check what direction player last faced
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            directionFaced = true;
            sr.flipX = !directionFaced;
        } 
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            directionFaced = false;
            sr.flipX = !directionFaced;
        }
    }
    #endregion
}
