using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    private GoombaScript scrGoomba;

    private void Awake()
    {
        scrGoomba = GetComponentInParent<GoombaScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Patrolmarkers")
        {
            scrGoomba.rotate();
            scrGoomba.faceDirection();
        }
    }
}
