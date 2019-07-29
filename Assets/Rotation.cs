using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 vect2;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        vect2.x = 4;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.transform.SetParent(gameObject.transform);
            rb2d.velocity = vect2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.transform.SetParent(null);
        }
    }
    //
    //{
    //collision.gameObject.transform.SetParent(transform.player, false);
    //}
}
