using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_Bandit : MonoBehaviour
{
    movement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponentInParent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            movement.detector = true;
            //movement.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            movement.detector = false;
    }
}
