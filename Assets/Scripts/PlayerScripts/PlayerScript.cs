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
                canMoveHori = true;
            }
            else
            {
                canMoveHori = false;
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
    #region canVariabler
    bool canMoveHori;
    bool canJumped;
    bool canDoubleJumped;
    #endregion
    #region IDEvariabler
    public float speed;
    public float jump;
    public float coyoteCD;

    public float wallJumpX;
    public float wallJumpY;

    public float wallSlideSpeed;
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
        WallSlide();
        Jump();
        DoubleJump();
        WallJump();

        print("Velocity: " + rb.velocity.y);
        //print("grounded: " + grounded);
        //print("canJumped: " + canJumped);
        //print("hasBeen: " + hasBeenGrounded);
        //print("input: " + Input.GetButtonDown("Vertical"));
        //print("Player: " + rb.transform.position);
        //print("Camera: " + GameObject.Find("Main Camera").transform.position);
    }

    void HorizontalMovement()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && canMoveHori)
        {
            if(!touchRight && Input.GetAxisRaw("Horizontal") > 0)
                rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            else if (!touchLeft && Input.GetAxisRaw("Horizontal") < 0)
                rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            else
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        //SLOW MOVMENT WHEN IN AIR
        /*else if (!grounded && Input.GetAxisRaw("Horizontal") != 0)
        {
            if (!touchRight && Input.GetAxisRaw("Horizontal") > 0)
                rb.velocity = new Vector2(speed / 2 * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            else if (!touchLeft && Input.GetAxisRaw("Horizontal") < 0)
                rb.velocity = new Vector2(speed / 2 * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            else
                rb.velocity = new Vector2(0, rb.velocity.y);
        }*/

    }


    public float wallSlideCD;
    float wallSlideTS;
    void WallSlide()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && (touchLeft || touchRight) && !Input.GetButtonDown("Vertical"))
        {
            if ((Input.GetAxisRaw("Horizontal") > 0 && touchRight) || (Input.GetAxisRaw("Horizontal") < 0 && touchLeft))
            {
                rb.velocity = new Vector2(rb.velocity.x, wallSlideSpeed * -1);
            }
        }
    }

    void Jump()
    {
        //print(Input.GetButtonDown("Vertical"));
        if (grounded == true && Input.GetButtonDown("Vertical") && canJumped)
        {
            canJumped = false;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //ani.SetBool("Jumping", true);
            //print("Jump: " + rb.velocity.y);
            //print("grounded: " + grounded);
            //print("canJumped: " + canJumped);
        }
        else if (!grounded && Input.GetButtonDown("Vertical") && coyoteTS >= Time.time && canJumped && canJumped)
        {
            canJumped = false;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //ani.SetBool("Jumping", true);
            //print("Jump Coyote: " + rb.velocity.y);
            //print("grounded: " + grounded);
            //print("canJumped: " + canJumped);
        }
    }

    void DoubleJump()
    {
        if (!grounded && Input.GetButtonDown("Vertical") && canDoubleJumped && canDoubleJumped)
        {
            canDoubleJumped = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = new Vector2(rb.velocity.x, jump);            
            //print("DoubleJump: " + rb.velocity.y);
        }
    }

    float stopMoveHoriTS;
    public float stopMoveHoriCD;
    void WallJump()
    {
        bool triggered = false;

        if (Input.GetButtonDown("Vertical") && touchRight && Input.GetAxisRaw("Horizontal") > 0)
        {
            canDoubleJumped = false;
            canJumped = false;

            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(wallJumpX * -1, wallJumpY);
            triggered = true;
            print("input vertical + touchRight + input Horizontal > 0");
            print("Velocity: " + rb.velocity.y);
        }
        else if (Input.GetButtonDown("Vertical") && touchLeft && Input.GetAxisRaw("Horizontal") < 0)
        {
            canDoubleJumped = false;
            canJumped = false;

            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(wallJumpX, wallJumpY);
            triggered = true;
            print("input vertical + touchLeft + input Horizontal < 0");
            print("Velocity: " + rb.velocity.y);
        }
        /*if ((Input.GetAxisRaw("Vertical") > 0 && touchRight && Input.GetAxisRaw("Horizontal") > 0) || (Input.GetAxisRaw("Vertical") > 0 && touchLeft && Input.GetAxisRaw("Horizontal") < 0))
        {
            float input = Input.GetAxisRaw("Horizontal");
            rb.velocity = Vector2.zero;
            print(rb.velocity);

            //wallJump = new Vector2(wallJumpX * -1, wallJumpY);
            wallJump = new Vector2(wallJumpX * Mathf.Round(input), wallJumpY);
            //rb.velocity = Vector2.Lerp(rb.position, wallJump, 0.1f);
            rb.velocity = wallJump;
            triggered = true;
            print("WallJump touchRight");
        }*/


        if (triggered)
        {
            canMoveHori = false;
            stopMoveHoriTS = Time.time + stopMoveHoriCD;
            //print("CanMoveHori trigger: " + canMoveHori);
        }

        if (stopMoveHoriTS <= Time.time)
        {
            canMoveHori = true;
            //print("CanMoveHori stopMove: " + canMoveHori);
        }     
        
    }

    /*#region StatusManipulators
    float stopHoriTimeTS;
    void StopHorizontalMove(float time, bool startTimer)
    {
        if (startTimer)
        {
            stopHoriTimeTS = Time.time + time;
            canMoveHori = false;
        }
    }
    #endregion*/

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
