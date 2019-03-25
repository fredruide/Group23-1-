using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Rigidbody2D playerRB;
    Vector2 playerVelocity;
    bool inBox;

    float moveTS = 0f;
    float outBoxMoveTS = 0f;
    public float moveCD;
    public float outBoxMoveCD;

    public float cameraSpeed;
    public float restingCameraSpeed;

    public float moveCameraX;
    public float moveCameraY;

    Vector3 velocity = Vector3.zero;
    Vector3 endPosistion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        playerVelocity = player.GetComponent<Rigidbody2D>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        moveTS += Time.deltaTime;

        endPosistion = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 3);
        //if(Input.GetAxisRaw("CamHorizontal") != 0 || Input.GetAxisRaw("CamVertical") != 0)
          //  JoyStickMove();
        //else
        Move();

        print("inbox: " + inBox);
        //print("TS: " + moveTS + " x: " + rb.position.x + " y: " + rb.position.y + " z: " + transform.position.z);
        print("AxisX: " + Input.GetAxisRaw("CamHorizontal") + " AxisY: " + Input.GetAxisRaw("CamVertical"));
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
            moveTS = 0f;
            rb.transform.position = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, cameraSpeed);
            //rb.velocity = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, cameraSpeed);
            //rb.velocity = playerVelocity;
            
            print("Óut of box move");
        }   
        else if (inBox && playerVelocity != Vector2.zero)
        {
            moveTS = 0f;
        }
        else if (moveTS >= moveCD && inBox)
        {
            rb.transform.position = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, restingCameraSpeed);
            //rb.velocity = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, restingCameraSpeed);

            print("Resting move");
        }
        else if (inBox)
        {
            print("Camera Stick move");

            moveTS = 0f;

            float x = Mathf.Round(Input.GetAxisRaw("CamHorizontal"));
            float y = Mathf.Round(Input.GetAxisRaw("CamVertical"));

            rb.velocity = new Vector2(x * moveCameraX, y * moveCameraY);
        }
        /*else if ((Input.GetAxisRaw("CamHorizontal") != 0 || Input.GetAxisRaw("CamVertical") != 0) && inBox)
        {
            print("Camera Stick move");

            moveTS = 0f;

            //float x = Mathf.Round(Input.GetAxisRaw("CamHorizontal"));
            //float y = Mathf.Round(Input.GetAxisRaw("CamVertical"));
            float x;
            if (Input.GetAxis("CamHorizontal") > 0)
                x = 1;
            else if (Input.GetAxis("CamHorizontal") < 0)
                x = -1;
            else
                x = 0;
            float y;
            if (Input.GetAxis("CamVertical") > 0)
                y = 1;
            else if (Input.GetAxis("CamVertical") < 0)
                y = -1;
            else
                y = 0;


            rb.velocity = new Vector2(x * moveCameraX, y * moveCameraY);
        }*/

        if (rb.position == playerRB.position)
        {
            moveTS = 0f;
        }

        if (outBoxMoveTS >= outBoxMoveCD)
        {

        }
    }

    void JoyStickMove()
    {

    }
}
