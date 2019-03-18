using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    GoombaScript GoombaScript;
    Rigidbody2D rb;


    private void Start()
    {
        GoombaScript = GetComponentInParent<GoombaScript>();
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D wall)
    {
        print(rb.gameObject.name + ": Trigger Enter" );

        if (wall.gameObject.tag == "Wall")
        {
            GoombaScript.terrainTrigger = wall;
        }
    }

    private void OnTriggerExit2D(Collider2D drop)
    {
        print(rb.gameObject.name + ": Trigger Exit");

        if (drop.gameObject.tag == "Platform")
        {
            GoombaScript.terrainTrigger = drop;
        }
        
    }
}