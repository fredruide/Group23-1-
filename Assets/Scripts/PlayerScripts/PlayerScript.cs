using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public SpriteRenderer sr;
    Animator ani;
    float aniSpeed;

    Camera mainCam;

    public GameObject objHPotion_Counter;
    public Material_Counter scrMC;

    //_isGrounded _touchLeft and _touchRight is set by the Bottom, left and right 
    // colliders attach to the player object

    
    //this bool and field is for checking if Right side of player
    //is in contact with a object (checks on platform only right now)
    //used in WallSlide, WallJump and HorizontalMovement methods
    bool touchRight;
    public bool _touchRight
    {
        get { return touchRight; }
        set
        {
            touchRight = value;
        }
    }
    //this bool and field is for checking if Left side of player
    //is in contact with a object (checks on platform only right now)
    //used in WallSlide, WallJump and HorizontalMovement methods
    bool touchLeft;
    public bool _touchLeft
    {
        get { return touchLeft; }
        set { touchLeft = value; }
    }
    //true = facing right : false = facing left
    //used to make sure player sprite is pointing the correct way (SpriteRender.FlipX)
    bool directionFaced;
    public bool _directionFaced
    {
        get { return directionFaced; }
    }
    #region canVariabler
    //the 3 can bools below are handlet in the _grounded field
    //name should make it clear what they are inteanted to check on


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
    //this bool and field is for checking if player can WallSlide
    bool canWallSlide;
    public bool _canWallSlide
    {
        get { return canWallSlide; }
        set
        {
            canWallSlide = value;
        }
    }
    #endregion
    #region isVariabler
    //this bool and field is for checking if bottom part of player
    //is in contact with a object (checks on platform only right now)
    //used in HorizontalMovement, Jump and DoubleJump methods.
    bool isGrounded;
    public bool _isGrounded
    {
        get { return isGrounded; }
        set
        {
            isGrounded = value;
            ani.SetBool("isGrounded", value);
            if (value == true)
            {
                canJump = true;
                //canDoubleJump = true;
                canMoveHori = true;
                ani.SetBool("isJumping", false);
                ani.SetBool("isAirborn", false);
                ani.SetBool("isWallSliding", false);
            }
            else
            {
                canMoveHori = false;
                _isAirborn = true;
                ani.SetBool("isAirborn", true);
            }
        }
    }

    bool isRunning;
    public bool _isRunning
    {
        get { return isRunning; }
        set
        {
            isRunning = value;
            if (isRunning)
                ani.SetBool("isRunning", true);
            else
                ani.SetBool("isRunning", false);
        }
    }
    //bool to se and set player as being Airborn
    bool isAirborn;
    // a field to handle the animator for when "isAirborn" is true or false
    //always set this field when anipulating isAirborn unless animator is to be skiped
    public bool _isAirborn
    {
        get { return isAirborn; }
        set
        {
            isAirborn = value;
            if (value == true)
                ani.SetBool("isAirborn", true);
            else
                ani.SetBool("isAirborn", false);
        }
    }
    //to see if player is wall sliding
    bool isWallSliding;
    // a field to handle the animator for when "isWallSliding" is true or false
    //always set this field when anipulating isWallSliding unless animator is to be skiped
    public bool _isWallSliding
    {
        get { return isWallSliding; }
        set
        {
            isWallSliding = value;
            if(value == true)
            {
                ani.SetBool("isWallSliding", true);
                ani.SetBool("isAirborn", false);
                //WallSLideAnimationHandler();
            }
            else
            {
                ani.SetBool("isWallSliding", false);
            }
        }
    }
    bool isDisabled;
    public bool _isDisabled
    {
        get { return isDisabled; }
    }
    #endregion
    #region IDEvariabler
    //the following variabler need to have a value assigned from a file later in the project.
    //for now they get value from the unity IDE

    //PLayer Horizontal movement speed
    public float speed;
    //player jump hieght
    public float jump;
    //lenght of coyote effect (how long after being not grounded player still can jump)
    public float coyoteCD;
    //used to pause horizontal movement when wall jumping
    public float stopMoveHoriCD;
    //how far player will be pushed Horizontal when wall jumping
    public float wallJumpX;
    //how far player will be pushed vertical when wall jumping
    public float wallJumpY;
    //how fast player falls to the ground when wall sliding
    public float wallSlideSpeed;
    #endregion
    #region TimeStamp
    //float used for coyote time length.
    //is meant to have Time.time assigned to it when used.
    float coyoteTS;
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

    public float invincFramesCD;
    public float _invincFramesCD
    {
        set { invincFramesCD = value; }
    }
    float invincFramesTS;
    public float _invincFramesTS
    {
        set { invincFramesTS = value + invincFramesCD; }
    }
    #endregion
    #region StatsVariabler
    //player current health
    private int currentHealth = 9;
    //player max health
    private int maxHealth = 10;

    public int _maxHealth
    {
        get { return maxHealth; }
    }

    public int _currentHealth
    {
        get { return currentHealth; }
    }
    //player respawn posisiton
    Vector2 respawnPosition;
    public Vector2 _respawnPosition
    {
        get { return respawnPosition; }
        set { respawnPosition = value; }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //rb is used to manipulate player rigid body
        rb = GetComponent<Rigidbody2D>();
        //sr is used to manipulated player sprite and animations sprites
        sr = GetComponent<SpriteRenderer>();
        //ani is used to manipulate and check on animation
        ani = GetComponent<Animator>();
        aniSpeed = ani.speed;
        //mainCam is used to check and manipulate the Main Camera in the scene
        //mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();  Bruges ikke  
    }

    float alive;

    private void Awake()
    {//J.C.
        objHPotion_Counter = GameObject.Find("Material_Counter");
        scrMC = objHPotion_Counter.GetComponent<Material_Counter>();

        alive = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        DirectionFacing();
        IsRunning();
        IsInvincible();
        IsDisabled(isDisabled);

        //grounded = true ? bottomTrigger.gameObject.tag == "Ground" : false;

        //ani.SetBool("Grounded", grounded);

        HorizontalMovement();        
        Jump();
        DoubleJump();
        WallJump();
        WallSlide();
        AttackChecker();
        UseHPotion();

        //print("ani isAttacking1-3: " + ani.GetInteger("isAttacking1-3"));
        //print("attackType: " + attackType);
        //print("");

        
        //print("ani isAttacking1-3: " + ani.GetInteger("isAttacking1-3"));
        //print("attackType: " + attackType);
        //print("");

        //print ani
        //if (Input.GetButton("Fire1"))
        //{
        //    Debug.Log("isGrounded: " + ani.GetBool("isGrounded"));
        //    Debug.Log("isInCombat: " + ani.GetBool("isInCombat"));
        //    Debug.Log("isRunning: " + ani.GetBool("isRunning"));
        //    Debug.Log("isJumping: " + ani.GetBool("isJumping"));
        //    Debug.Log("isAirborn: " + ani.GetBool("isAirborn"));
        //    Debug.Log("isWallSliding: " + ani.GetBool("isWallSliding"));
        //    Debug.Log("isAttacking1-3: " + ani.GetInteger("isAttacking1-3"));
        //}
        //
        //Debug.Log("out of if isAttacking1-3: " + ani.GetInteger("isAttacking1-3"));
        //print("isWallSliding: " + isWallSliding);
        //print(PlayerRangedAttack.isNotDrawing);
        //print("isWallSlide: " + _isWallSliding + " ani.isWallSlide: " + ani.GetBool("isWallSliding"));
        //print("isAirborn: " +_isAirborn + " ani.isAirborn: " + ani.GetBool("isAirborn"));
        //print("IsInvincible: " + IsInvincible());
        //print(Input.GetJoystickNames().Length);

        //print(Input.GetAxis("Horizontal") + " " + Input.GetButton("Horizontal"));
        //print("Velocity: " + rb.velocity.y);
        //print("Velocity: " + rb.velocity.y);SDW
        //print("isGrounded: " + isGrounded);
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

    void HorizontalMovement()
    {
        //check is player is clicking a move horizontal button and is canMoveHori is true
        //canMoveHori is set to false when grounded is set to false
        if (Input.GetButton("Horizontal") && canMoveHori && PlayerRangedAttack.isNotDrawing)
        {
            //checks if player is colliding with a object on the same side at they are moving
            //if true then stop moving to prevent false sliding
            //if player is not clicking a move Horizontal button then stop velocity horizontal (else statment)
            if (!touchRight && Input.GetAxisRaw("Horizontal") > 0)
            {
                rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            }
            else if (!touchLeft && Input.GetAxisRaw("Horizontal") < 0)
            {
                rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }    
        }
        else if (!Input.GetButton("Horizontal") && canMoveHori)
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

    void WallSlide()
    {
        //the 3 if statments could have been one long if statment
        //checks if player is not grounded and if canWallSlide is true (canWallSlide is set to true when first coliding with an object)
        //and set to false under WallJump method and in LeftTriggerScript and RightTriggerScript
        if (canWallSlide && !isGrounded)
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
                    _isWallSliding = true;                    
                }
                else
                {
                    _isWallSliding = false;
                }
            }
            else
            {
                _isWallSliding = false;
            }
        }
        else
        {
            _isWallSliding = false;
        }
    }

    void Jump()
    {
        //print(Input.GetButtonDown("Vertical"));
        
        //check is player is clicking vertical button and is grounded and canJump is true
        //(canJump is set to true when grounded is first set to true)
        if (isGrounded == true && Input.GetButtonDown("Vertical") && canJump && PlayerRangedAttack.isNotDrawing)
        {
            canJump = false;
            canDoubleJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            ani.SetBool("isJumping", true);
            //print("Jump: " + rb.velocity.y);
            //print("grounded: " + grounded);
            //print("canJump: " + canJump);
            //FindObjectOfType<AudioManager>().Play("Jump");
        }
        //if player can´t jump under normal conditions check if player can jump under coyote conditions
        else if (!isGrounded && Input.GetButtonDown("Vertical") && coyoteTS >= Time.time && canJump)
        {
            canJump = false;
            canDoubleJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jump);
            ani.SetBool("isJumping", true);
            //print("Jump Coyote: " + rb.velocity.y);
            //print("grounded: " + grounded);
            //print("canJump: " + canJump);
        }
        else
        {
            ani.SetBool("isJumping", false);
        }
    }

    void DoubleJump()
    {
        //checks if player is not grounded, player can double jump and player is double jumping
        if (!isGrounded && Input.GetButtonDown("Vertical") && canDoubleJump && coyoteTS < Time.time)
        {
            canDoubleJump = false;
            //set velocity in y to zero so double jump can´t be used to gain more velocity when normal jumping
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = new Vector2(rb.velocity.x, jump);

            ani.SetBool("isJumping", true);
            //FindObjectOfType<AudioManager>().Play("DoubleJump");
        }
    }


    void WallJump()
    {
        //check if player is clicking the horizontale move button that matches the side 
        //that the wall they are coliding with is on and that the player is trying to jump
        //the if statment is for walljumping to the left
        if (Input.GetButtonDown("Vertical") && touchRight && Input.GetAxisRaw("Horizontal") > 0 && !isGrounded)
        {
            //set player velocity to zero in x and y 
            rb.velocity = Vector2.zero;
            //set player velocity to wall jump x and y velocitys
            rb.velocity = new Vector2(wallJumpX * -1, wallJumpY);
            isDisabled = true;
            _isGrounded = false;
            //print("input vertical + touchRight + input Horizontal > 0");
            //print("Velocity: " + rb.velocity.y);
        }
        //the else if statment is to walljump to the right
        else if (Input.GetButtonDown("Vertical") && touchLeft && Input.GetAxisRaw("Horizontal") < 0 && !isGrounded)
        {
            //set player velocity to zero in x and y 
            rb.velocity = Vector2.zero;
            //set player velocity to wall jump x and y velocitys
            rb.velocity = new Vector2(wallJumpX, wallJumpY);
            isDisabled = true;
            _isGrounded = false;
            //print("input vertical + touchLeft + input Horizontal < 0");
            //print("Velocity: " + rb.velocity.y);
        }    
    }

    #region StateManipulators    
    void IsDisabled(bool playerDisabled)
    {
        if (playerDisabled)
        {
            canMoveHori = false;
            canDoubleJump = false;
            canJump = false;
            canWallSlide = false;

            _stopMoveHoriTS = Time.time;
            isDisabled = false;
            //print("CanMoveHori trigger: " + canMoveHori);
        }
        //if timer is below current time allow horizontal movement agien
        if (stopMoveHoriTS <= Time.time)
        {
            canMoveHori = true;

            //print("CanMoveHori stopMove: " + canMoveHori);
        }
    }

    float knockbackX;
    float knockbackY;
    Vector3 enamyPosistion;

    public void KnockbackSetter(float xForce, float yForce, Vector3 enamyPosistion)
    {
        knockbackX = xForce;
        knockbackY = yForce;
        this.enamyPosistion = enamyPosistion;
    }

    void KnockBack()
    {
        IsDisabled(true);

        if (enamyPosistion.x > rb.transform.position.x)
        {
            knockbackX = -knockbackX;
        }
        if (enamyPosistion.y > rb.transform.position.y)
        {
            knockbackY = -knockbackY;
        }
        rb.velocity = new Vector2(knockbackX, knockbackY);        
    }

    public void TakeDamage(int dmg)
    {
        if (IsInvincible() == false)
        {
            currentHealth -= dmg;
            KnockBack();
            _invincFramesTS = Time.time;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        scrMC.Death();

        rb.transform.position = respawnPosition;
    }

    void UseHPotion()
    {//J.C.
        if (Input.GetButtonDown("Heal") && scrMC.HPotionUsed() >= 1 && currentHealth < maxHealth)
        {
            
            Heal(1);
            int usedPotion = -1;
            scrMC.CheckForHPotion(usedPotion);
        }
    }

    void Heal(int heal)
    {
        if (heal + currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
            
        else
        {
            currentHealth += heal;
        }
    }

    #endregion
    #region HelperMethods
    void DirectionFacing()
    {
        //print(PlayerRangedAttack.isNotDrawing);
        if (PlayerRangedAttack.isNotDrawing)
        {
            //check what direction player last faced
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                directionFaced = false;
                sr.flipX = directionFaced;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                directionFaced = true;
                sr.flipX = directionFaced;
            }
        }
    }
    void IsRunning()
    {
        /*
        if (Input.GetButton("Horizontal") && canMoveHori && isGrounded && rb.velocity.x != 0)
        {
            isRunning = true;
            ani.SetBool("isRunning", true);
        }
        else
        {
            isRunning = false;
            ani.SetBool("isRunning", false);
        }
        */
        if (Input.GetButton("Horizontal") && canMoveHori && isGrounded)
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

    bool flashy = true;
    bool IsInvincible()
    {
        if (Time.time <= invincFramesTS)
        {
            sr.enabled = flashy;
            flashy = !flashy;

            return true;
        }
        else
        {
            sr.enabled = true;
            return false;
        }
    }

    void StopAnimation()
    {
        if (!PlayerRangedAttack.isNotDrawing)
        {
            ani.speed = 0;
        }            
    }
    public void StartAnimation()
    {
        ani.speed = aniSpeed;
    }
    //Frederik
    //Bruges ikke p.t
    void WallSLideAnimationHandler()
    {
        if(ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Wall_Slide"))
        {
            //Debug.Log("Success!");
            //print("Success");
            //print(this.gameObject.transform.childCount);
            GameObject Child;

            for (int i = 0; i < gameObject.transform.childCount -1; i++)
            {
                if (gameObject.transform.GetChild(i).name == "LeftWallSlideAni")
                {
                    Child = gameObject.transform.GetChild(i).gameObject;
                    if (touchLeft)
                    {
                        Child.GetComponent<Animator>().enabled = true;
                        Child.GetComponent<Animator>().Play("Player_Wall_Slide");
                        break;
                    }
                    else
                    {
                        Child.SetActive(false);
                    }
                }
                if (gameObject.transform.GetChild(i).name == "RightWallSlideAni")
                {
                    Child = gameObject.transform.GetChild(i).gameObject;
                    if (touchRight)
                    {
                        Child.GetComponent<Animator>().enabled = true;
                        Child.GetComponent<Animator>().Play("Player_Wall_Slide");
                        break;
                    }
                    else
                    {
                        Child.SetActive(false);
                    }
                }
            }
        }
    }
    #endregion

    #region Attack 
    //Daniel lille bitte smule hjælp fra frederik{
    public float timeBtwAttack; //Countdown fra startTimeBtwAttack til 0
    public float startTimeBtwAttack; //Sætter initial counter TimeBtwAttack (Bruges til cooldown af attacks så knappen ikke kan blive spammet med 1ms imellem tryk)
    public Transform attackPos; //Et child object af player som bestemmer hvor der bliver attacked fra
    public LayerMask whatisEnemy = 11; //Checker efter Enemy Layer
    public float attackRange; //Range på det første attack i chain
    public float attackRange1; //Range på det andet attack i chain
    public float attackRange2; //Range på det tredje attack i chain
    public int damage; //Attack damage på det første attack i chain
    public int damage1; //Attack damage på det andet attack i chain
    public int damage2; //Attack damage på det tredje attack i chain
    public int attackType = 1; //Bestemmer hvad for et attack der bliver det næste i chain
    public float attackGracePeriod; //Countdown fra startTimeBtwGrace til 0
    public float startTimeBtwGrace; //Sætter initial counter til attackGracePeriod (Bruges til at resette attacktype til 1 hvis der ikke bliver angrebet i et stykke tid)

    void AttackChecker()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetButtonDown("Fire1") && attackType == 1) //Første angreb i chain
            {
                //print("AttackType 1");
                MeleeAttack(damage, attackRange);
                //ani.SetInteger("isAttacking1-3", 1);
                ani.SetBool("AttackType1", true);
            }
            else if (Input.GetButtonDown("Fire1") && attackType == 2) //andet angreb i chain
            {
                MeleeAttack(damage1, attackRange1);
                //print("AttackType 2");
                //ani.SetInteger("isAttacking1-3", 2);
                ani.SetBool("AttackType2", true);
            }
            else if (Input.GetButtonDown("Fire1") && attackType == 3) //tredje angreb i chain
            {
                MeleeAttack(damage2, attackRange2);
                //print("AttackType 3");
                //ani.SetInteger("isAttacking1-3", 3);
                attackGracePeriod = 0;
                ani.SetBool("AttackType3",true);
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        if (attackGracePeriod <= 0) //Sætter attack type tilbage til 1 når grace perioden rammer 0
        {
            attackType = 1;
            //ani.SetBool("AttackType1", false);
            //ani.SetBool("AttackType2", false);
            //ani.SetBool("AttackType3", false);
            //ani.SetInteger("isAttacking1-3", 0);
        }
        else
        {
            attackGracePeriod -= Time.deltaTime;
        }
    }

    private void MeleeAttack(int dmg, float range)
    {
        
        attackGracePeriod = startTimeBtwGrace; //Resetter graceperiod til valuen af startTimeBtwGrace
        timeBtwAttack = startTimeBtwAttack; //Resetter Cooldown til valuen af StarTimeBtwAttack
        
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, range, whatisEnemy); //Checker efter enemies og putter dem i et array (EnemiesToDamage)
        if (enemiesToDamage.Length != 0)
        {
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyTest>().TakeDmg(dmg);
                enemiesToDamage[i].GetComponent<Worm_DamageTaken>().TakeDmg(dmg);
            }            
        }
        attackType++;
        //print("Melee Attack");
    } // }
    #endregion
    #region Sound
    //Daniel
    void RunSound()
    {
        //FindObjectOfType<AudioManager>().Play("Walk");
    }
    void AttackSound()
    {
        //FindObjectOfType<AudioManager>().Play("Attack1");
    }
    #endregion

}
