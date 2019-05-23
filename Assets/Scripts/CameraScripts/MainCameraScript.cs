using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;
    GameObject player;
    Rigidbody2D playerRB;
    Vector2 playerVelocity;
    bool inBox;
    bool moveCameraStick;

    [HideInInspector]
    bool topTrigger;
    [HideInInspector]
    bool rightTrigger;
    [HideInInspector]
    bool bottomTrigger;
    [HideInInspector]
    bool leftTrigger;

    public bool _topTrigger
    {
        get { return topTrigger; }
        set { topTrigger = value; }
    }
    public bool _rightTrigger
    {
        get { return rightTrigger; }
        set { rightTrigger = value; }
    }
    public bool _bottomTrigger
    {
        get { return bottomTrigger; }
        set { bottomTrigger = value; }
    }
    public bool _leftTrigger
    {
        get { return leftTrigger; }
        set { leftTrigger = value; }
    }

    float moveTS = 0f;
    public float moveCD;

    public float cameraSpeed;
    public float restingCameraSpeed;

    public float moveCameraX;
    public float moveCameraY;

    public float cameraSize;

    Vector3 velocity = Vector3.zero;
    Vector3 endPosistion;
    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        player = GameObject.Find("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        playerVelocity = player.GetComponent<Rigidbody2D>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        moveTS += Time.deltaTime;

        endPosistion = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 3);
        
        //moveCameraStick = MoveCameraLimit();

        Move();

        //print("inbox: " + inBox);
        //print("TS: " + moveTS + " x: " + rb.position.x + " y: " + rb.position.y + " z: " + transform.position.z);
        //print("Top: " + topTrigger);
        //print("Right: " + rightTrigger);
        //print("Bottom: " + bottomTrigger);
        //print("Left: " + leftTrigger);
        //print("AxisX: " + Input.GetAxisRaw("CamHorizontal") + " AxisY: " + Input.GetAxisRaw("CamVertical"));
        //print("ColliderPosistionX: " + col.transform.position.x + " ColliderPosistionY: " + col.transform.position.y);
        //print("CamPosistionX: " + transform.position.x + " CamPosistionY: " + transform.position.y);
        //print("PlayerPosistionX: " + playerRB.transform.position.x + " PlayerPosistionY: " + playerRB.transform.position.y);
        //print("velocity: " + rb.velocity);
        //print("Collider Size X: " + rb.GetComponent<Collider2D>().transform.lossyScale.x + " Collider Size Y: " + rb.GetComponent<Collider2D>().transform.lossyScale.y);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject == player)
        {
            inBox = true;            
        }
        //print("Enter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.gameObject == player)
        {
            inBox = true;           
        }
        //print("Stay");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            inBox = false;
            moveTS = 0f;
        }
        //print("Exit");
    }


    void Move()
    {
        if (!inBox)
        {
            rb.velocity = Vector2.zero;
        }

        if (inBox && playerVelocity != Vector2.zero)
        {
            moveTS = 0f;
        }

        if (rb.position == playerRB.position)
        {
            moveTS = 0f;
        }

        if (Input.GetAxis("CamHorizontal") != 0 || Input.GetAxis("CamVertical") != 0)
        {
            moveCameraStick = true;
        }
        else
        {
            moveCameraStick = false;
            rb.velocity = Vector2.zero;
        }

        if (!inBox && !moveCameraStick)
        {
            velocity = playerRB.velocity;
            rb.velocity = Vector2.zero;
            moveTS = 0f;
            rb.transform.position = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, cameraSpeed);
            //rb.velocity = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, cameraSpeed);
            //rb.velocity = playerVelocity;

            //print("Óut of box move");
        }
        else if (inBox && moveCameraStick)
        {
            //print("Camera Stick move");
            moveTS = 0f;
            float x = Input.GetAxisRaw("CamHorizontal");
            float y = Input.GetAxisRaw("CamVertical");

            if (Input.GetAxis("CamHorizontal") > 0 && leftTrigger)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else if (Input.GetAxis("CamHorizontal") < 0 && rightTrigger)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else if (Input.GetAxis("CamVertical") > 0 && bottomTrigger)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            else if (Input.GetAxis("CamVertical") < 0 && topTrigger)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            else
                rb.velocity = new Vector2(Input.GetAxisRaw("CamHorizontal") * moveCameraX, Input.GetAxisRaw("CamVertical") * moveCameraY);

            //print("X: " + x + " Y: " + y + " Velocity: " + rb.velocity);
        }
        else if (moveTS >= moveCD && inBox)
        {
            rb.velocity = Vector2.zero;
            rb.transform.position = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, restingCameraSpeed);
            //rb.velocity = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, restingCameraSpeed);

            //print("Resting move");
        }
    }
}
