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
        Move();
        print("TS: " + moveTS + " x: " + rb.position.x + " y: " + rb.position.y + " z: " + transform.position.z);
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
            rb.transform.position = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, cameraSpeed);
            //rb.velocity = playerVelocity;
        }   
        else if (inBox && playerVelocity != Vector2.zero)
        {
            moveTS = 0f;
        }

        if (rb.position == playerRB.position)
        {
            moveTS = 0f;
        }

        if (outBoxMoveTS >= outBoxMoveCD)
        {

        }

        if (moveTS >= moveCD && inBox)
        {
            rb.transform.position = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, restingCameraSpeed);
        }
    }
}
