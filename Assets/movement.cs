using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D body;
    BoxCollider2D boxcollider;
    BoxCollider2D childbox;
    float movementcounter = 0;
    public bool detector;

    
    //public Vector2 velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
        childbox = GetComponentInChildren<BoxCollider2D>();
        body.velocity = new Vector2(7, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(body.velocity);
        //Debug.Log(movementcounter);
        Debug.Log(detector);
        //velocity = new Vector2(5, 0);
        movementcounter += Time.deltaTime;
        if (detector == true)
        {
            //body.transform.position = Vector2.SmoothDamp(body.transform.position, GameObject.Find("Player").transform.position, ref velocity, 7);

            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, 0.01f);
        }
        else
        {
            if (movementcounter < 5)
            {
                body.velocity = new Vector2(7, 0);

            }
            else
            {
                body.velocity = new Vector2(-7, 0);
            }
            if (movementcounter >= 10)
            {
                movementcounter = 0;
            }
        }

    }

}
