using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTriggerScript : MonoBehaviour
{
    //Rigidbody2D rb;
    PlayerScript ps;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        ps = GetComponentInParent<PlayerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ps.leftTrigger = collision;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //ps.leftTrigger = collision;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //ps.leftTrigger = collision;
    }
}
