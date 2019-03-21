using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Vector2 playerVelocity;
    bool inBox;
    bool restPoint;
    bool restTime;
    public float restPointCD;
    float restPointTS;

    public float cameraSpeed;

    Vector3 velocity = Vector3.zero;
    Vector3 endPosistion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //playerVelocity = player.GetComponent<Rigidbody2D>().velocity;       
        Move();
        //RestTime();
        //RestPoint();
        
        //print("player" + player.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject == player && playerVelocity == Vector2.zero)
        {
            inBox = true;            
        }
        //print("Enter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject == player && playerVelocity == Vector2.zero)
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
        }
        //print("Exit");
    }

    void Move()
    {
        if (!inBox)
        {
            endPosistion = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 3);
            rb.transform.position = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, cameraSpeed);
            //rb.velocity = playerVelocity;
        }   
    }

    void RestPoint()
    {
        endPosistion = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 3);
        rb.transform.position = Vector3.SmoothDamp(rb.transform.position, endPosistion, ref velocity, 1f);
    }

    void RestTime()
    {
        if(restTime)
            restPointTS = Time.time + restPointCD;
    }
}
