﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb; // Frederik{
    SpriteRenderer sr;
    Animator ani;
    Camera mainCam; // } Frederik

    //_grounded _touchLeft and _touchRight is set by the Bottom, left and right 
    // colliders attach to the player object

    //this bool and field is for checking if bottom part of player
    //is in contact with a object (checks on platform only right now)
    //used in HorizontalMovement, Jump and DoubleJump methods.
    bool grounded; // Frederik{
    public bool _grounded
    {
        get { return grounded; }
        set
        {
            grounded = value;
            ani.SetBool("isGrounded", value);
            if (value == true)
            {
                canJump = true;
                canDoubleJump = true;
                canMoveHori = true;
            }
            else
            {
                canMoveHori = false;
            }
        }
    } // } Frederik
    //this bool and field is for checking if Right side of player
    //is in contact with a object (checks on platform only right now)
    //used in WallSlide, WallJump and HorizontalMovement methods
    bool touchRight; // Frederik {
    public bool _touchRight
    {
        get { return touchRight; }
        set { touchRight = value; }
    } // } Frederik
    //this bool and field is for checking if Left side of player
    //is in contact with a object (checks on platform only right now)
    //used in WallSlide, WallJump and HorizontalMovement methods
    bool touchLeft; // Frederik {
    public bool _touchLeft
    {
        get { return touchLeft; }
        set { touchLeft = value; }
    } // } Frederik
    //true = facing right : false = facing left
    //used to make sure player sprite is pointing the correct way (SpriteRender.FlipX)
    bool directionFaced; // Frederik {
    public bool _directionFaced
    {
        get { return directionFaced; }
    } // } Frederik
    #region canVariabler
    //the 3 can bools below are handlet in the _grounded field
    //name should make it clear what they are inteanted to check on
<<<<<<< HEAD
    bool canMoveHori; //Frederik {
    public bool _canMoveHori
    {
        get { return canMoveHori; }
        set { canMoveHori = value; }
    }
    bool canJump;
    public bool _canJump
    {
        get { return canJump; }
        set { canJump = value; }
    }
    bool canDoubleJump; // } Frederik
    public bool _canDoubleJump
    {
        get { return canDoubleJump; }
        set { canDoubleJump = value; }
    }
=======
    public static bool canMoveHori;
    public static bool canJump;
    bool canDoubleJump;
>>>>>>> e2c6d49c4301ccd9265cebede8a0741e0924ec15

    //this bool and field is for checking if player can WallSlide
    bool canWallSlide; // Frederik {
    public bool _canWallSlide
    {
        get { return canWallSlide; }
        set
        {
            canWallSlide = value;
        }
    } // } Frederik 
    #endregion
    #region isVariabler
    bool isRunning; // Frederik {
    public bool _isRunning
    {
        get { return isRunning; }
    }
    bool isAirborn;
    public bool _isAirborn
    {
        get { return isAirborn; }
    }
    bool isInCombat;
    public bool _isInCombat
    {
        get { return isInCombat; }
    } // } Frederik
    #endregion
    #region IDEvariabler
    //the following variabler need to have a value assigned from a file later in the project.
    //for now they get value from the unity IDE
    
    //PLayer Horizontal movement speed
    public float speed; // Frederik {
    //player jump hieght
    public float jump;
    //lenght of coyote effect (how long after being not grounded player still can jump)
    public float coyoteCD;
    //used to pause horizontal movement when wall jumping
    public float stopMoveHoriCD;
    //used to see how long player should stay in combat
    [SerializeField]
    public float isInCombatCD;
    //how far player will be pushed Horizontal when wall jumping
    public float wallJumpX;
    //how far player will be pushed vertical when wall jumping
    public float wallJumpY;
    //how fast player falls to the ground when wall sliding
    public float wallSlideSpeed; // } Frederik

    #endregion
    #region TimeStamp
    //float used for coyote time length.
    //is meant to have Time.time assigned to it when used.
    float coyoteTS; // Frederik
    public float _coyoteTS
    {
        set { coyoteTS = value + coyoteCD; }
    }
    //floats used to check that secound wall jump is not triggerd befor first one is done
    float stopMoveHoriTS;
    private float _stopMoveHoriTS
    {
        set { stopMoveHoriTS = value + stopMoveHoriCD; }
    }
    float isInCombatTS;
    private float _isInCombatTS
    {
        set { isInCombatTS = value + isInCombatCD; }
    } // } Frederik
    #endregion
    #region StatsVariabler
    //player current health
    public int health; // Frederik {
    //player max health
    public int maxHealth;
    //player respawn posisiton
    Vector2 respawnPosition; // } Frederik
    #endregion
    #region DanielVariabler
    float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatisEnemy;
    public float attackRange;
    public float attackRange1;
    public float attackRange2;
    public int damage;
    public int damage1;
    public int damage2;
    int attackType;
    float attackGracePeriod;
    public float startTimeBtwGrace;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //rb is used to manipulate player riged body
        rb = GetComponent<Rigidbody2D>(); // Frederik {
        //sr is used to manipulated player sprite and animations sprites
        sr = GetComponent<SpriteRenderer>();
        //ani is used to manipulate and check on animation
        ani = GetComponent<Animator>();
        //mainCam is used to check and manipulate the Main Camera in the scene
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>(); // } Frederik

    }
    // Update is called once per frame
    private void Update()
    {
        DirectionFacing(); // Frederik {
        IsRunning();
        IsInCombat();


        HorizontalMovement();        
        Jump();
        DoubleJump();
        WallJump();
        WallSlide(); // } Frederik

        Attack(); // Daniel

        //print("Attack: " + Input.GetButton("Fire1"));
        //print(Input.GetAxis("Horizontal") + " " + Input.GetButton("Horizontal"));
        //print("Velocity: " + rb.velocity.y);
        //print("Velocity: " + rb.velocity.y);SDW
        //print("grounded: " + grounded);
        //print("canJump: " + canJump);
        //print("hasBeen: " + hasBeenGrounded);
        //print("input: " + Input.GetButtonDown("Vertical"));
        //print("Player: " + rb.transform.position);
        //print("Camera: " + GameObject.Find("Main Camera").transform.position);

        //if (grounded)
        //print("Grounded: " + grounded);
        //if (!touchRight)
        //print("TouchRight: " + touchRight);
        //if (Input.GetButtonDown("Vertical"))
        //print("input Vertical: " + Input.GetButtonDown("Vertical"));
    }

    // Update is called once per frame at a fixed framerate of 60 fps
    void FixedUpdate()
    {
        /*
        DirectionFacing();
        //grounded = true ? bottomTrigger.gameObject.tag == "Ground" : false;

        //ani.SetBool("Grounded", grounded);
       

        HorizontalMovement();
        WallSlide();
        Jump();
        DoubleJump();
        WallJump();

        //print("Velocity: " + rb.velocity.y);
        //print("grounded: " + grounded);
        //print("canJump: " + canJump);
        //print("hasBeen: " + hasBeenGrounded);
        //print("input: " + Input.GetButtonDown("Vertical"));
        //print("Player: " + rb.transform.position);
        //print("Camera: " + GameObject.Find("Main Camera").transform.position);

        //if (grounded)
            //print("Grounded: " + grounded);
        //if (!touchRight)
            //print("TouchRight: " + touchRight);
        if (Input.GetButtonDown("Vertical"))
            print("input Vertical: " + Input.GetButtonDown("Vertical"));

        */
    }

    void HorizontalMovement() // Frederik
    {
        //check is player is clicking a move horizontal button and is canMoveHori is true
        //canMoveHori is set to false when grounded is set to false
        if (Input.GetButton("Horizontal") && canMoveHori && PlayerRangedAttack.isNotReloading)
        {
            //checks if player is colliding with a object on the same side at they are moving
            //if true then stop moving to prevent false sliding
            //if player is not clicking a move Horizontal button then stop velocity horizontal (else statment)
            if (!touchRight && Input.GetAxisRaw("Horizontal") > 0)
                rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            else if (!touchLeft && Input.GetAxisRaw("Horizontal") < 0)
                rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            else
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (!Input.GetButton("Horizontal"))
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

    void WallSlide() // Frederik
    {
        //the 3 if statments could have been one long if statment
        //checks if player is not grounded and if canWallSlide is true (canWallSlide is set to true when first coliding when a object)
        //and set to false under WallJump method and in LeftTriggerScript and RightTriggerScript
        if (canWallSlide && !grounded)
        {
            //checks is player is clicking a move horizontal button and is thouching a object on there left or right side
            // and is not trying to jump
            if (Input.GetButton("Horizontal")  && (touchLeft || touchRight) && !Input.GetButton("Vertical"))
            {
                //checks if the players horizontale movement direction is the same direction as  
                // player is coliding with an object
                if ((Input.GetAxisRaw("Horizontal") > 0 && touchRight) || (Input.GetAxisRaw("Horizontal") < 0 && touchLeft))
                {
                    //set players y velocity to the minus version of wallSlideSpeed 
                    rb.velocity = new Vector2(rb.velocity.x, wallSlideSpeed * -1);
                }
            }
        }
        /*
        if (canWallSlide && !grounded)
        {            
            if (Input.GetAxisRaw("Horizontal") != 0 && (touchLeft || touchRight) && !Input.GetButtonDown("Vertical"))
            {
                if ((Input.GetAxisRaw("Horizontal") > 0 && touchRight) || (Input.GetAxisRaw("Horizontal") < 0 && touchLeft))
                {
                    rb.velocity = new Vector2(rb.velocity.x, wallSlideSpeed * -1);
                }
            }
        }
        */
    }

    void Jump() // Frederik
    {
        //print(Input.GetButtonDown("Vertical"));

        //check is player is clicking vertical button and is grounded and canJump is true
        //(canJump is set to true when grounded is first set to true)
        if (grounded == true && Input.GetButtonDown("Vertical") && canJump && PlayerRangedAttack.isNotReloading)
        {
            canJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //ani.SetBool("Jumping", true);
            //print("Jump: " + rb.velocity.y);
            //print("grounded: " + grounded);
            //print("canJump: " + canJump);
        }
        //if player can´t jump under normal conditions check if player can jump under coyote conditions
        else if (!grounded && Input.GetButtonDown("Vertical") && coyoteTS >= Time.time && canJump)
        {
            canJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            //ani.SetBool("Jumping", true);
            //print("Jump Coyote: " + rb.velocity.y);
            //print("grounded: " + grounded);
            //print("canJump: " + canJump);
        }
    }

    void DoubleJump() // Frederik
    {
        //checks if player is not grounded, player can double jump and player is double jumping
        if (!grounded && Input.GetButtonDown("Vertical") && canDoubleJump)
        {
            canDoubleJump = false;
            //set velocity in y to zero so double jump can´t be used to gain more velocity when normal jumping
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = new Vector2(rb.velocity.x, jump);            
            //print("DoubleJump: " + rb.velocity.y);
        }
    }


    void WallJump() // Frederik
    {
        bool triggered = false;

        //check if player is clicking the horizontale move button that matches the side 
        //that the wall they are coliding with is on and that the player is trying to jump
        //the if statment is for walljumping to the left
        if (Input.GetButtonDown("Vertical") && touchRight && Input.GetAxisRaw("Horizontal") > 0 && !grounded)
        {
            //set player velocity to zero in x and y 
            rb.velocity = Vector2.zero;
            //set player velocity to wall jump x and y velocitys
            rb.velocity = new Vector2(wallJumpX * -1, wallJumpY);
            triggered = true;
            //print("input vertical + touchRight + input Horizontal > 0");
            //print("Velocity: " + rb.velocity.y);
        }
        //the else if statment is to walljump to the right
        else if (Input.GetButtonDown("Vertical") && touchLeft && Input.GetAxisRaw("Horizontal") < 0 && !grounded)
        {
            //set player velocity to zero in x and y 
            rb.velocity = Vector2.zero;
            //set player velocity to wall jump x and y velocitys
            rb.velocity = new Vector2(wallJumpX, wallJumpY);
            triggered = true;
            //print("input vertical + touchLeft + input Horizontal < 0");
            //print("Velocity: " + rb.velocity.y);
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

        //set time for next avalible wall jump if a wall jump was performed
        if (triggered)
        {
            canMoveHori = false;
            canDoubleJump = false;
            canJump = false;
            canWallSlide = false;

            _stopMoveHoriTS = Time.time;
            //print("CanMoveHori trigger: " + canMoveHori);
        }
        //if timer is below current time allow horizontal movement agien
        if (stopMoveHoriTS <= Time.time)
        {
            canMoveHori = true;
            //print("CanMoveHori stopMove: " + canMoveHori);
        }     
        
    }
    void Attack() // Daniel
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetButton("Fire1") && attackType == 1)
            {
                MeleeAttack(damage, attackRange);
                print("Attack 1");
            }
            else if (Input.GetButton("Fire1") && attackType == 2)
            {
                MeleeAttack(damage1, attackRange1);
                print("Attack 2");
            }
            else if (Input.GetButton("Fire1") && attackType == 3)
            {
                MeleeAttack(damage2, attackRange2);
                print("Attack 3");
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        attackGracePeriod -= Time.deltaTime;
        if (attackGracePeriod <= 0)
        {
            attackType = 1;
        }
    }
    #region StatManipulators
    public void TakeDamage(int dmg) // Frederik
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            _isInCombatTS = Time.time;
        }
    }

    void Die() // Frederik
    {
        rb.transform.position = respawnPosition;
    }

    void Heal(int heal) // Frederik
    {
        if (heal + health > maxHealth)
            health = maxHealth;
        else
            health += heal;
    }

    void SetRespawn(Vector2 newRespawn) // Frederik
    {
        respawnPosition = newRespawn;
    }
    #endregion
    #region HelperMethods
    void DirectionFacing() // Frederik
    {
        //check what direction player last faced
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            directionFaced = true;
            sr.flipX = directionFaced;
        } 
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            directionFaced = false;
            sr.flipX = directionFaced;
        }
    }
    void IsRunning() // Frederik
    { 
        if (Input.GetButton("Horizontal") && canMoveHori && grounded && rb.velocity.x != 0)
        {
            isRunning = true;
            ani.SetBool("isRunning", true);
        }
        else
        {
            isRunning = false;
            ani.SetBool("isRunning", false);
        }
    }
    void IsAirborn() // Frederik
    {
        if (!grounded)
        {
            isAirborn = true;
            ani.SetBool("isAirborn", true);
        }
        else
        {
            isAirborn = false;
            ani.SetBool("isAirborn", false);
        }
    }
    void IsInCombat() // Frederik
    {
        if (isInCombatTS <= Time.time)
        {
            isInCombat = false;
            ani.SetBool("isInCombat", false);
        }
        else
        {
            isInCombat = true;
            ani.SetBool("isInCombat", true);
        }
    }
    private void MeleeAttack(int dmg, float range) // Daniel
    {
        attackGracePeriod = startTimeBtwGrace;
        timeBtwAttack = startTimeBtwAttack;
        Collider2D[]
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, whatisEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyTest>().TakeDmg(dmg);
        }
        attackType++;
        _isInCombatTS = Time.time;
        ani.SetBool("isAttacking", true);
    }
    #endregion
}

