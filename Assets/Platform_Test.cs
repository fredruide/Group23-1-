using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Test : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 vect2d;
    private float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        vect2d.x = speed;
        rb2d.velocity = vect2d;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            speed = -4f;
            rb2d.velocity = vect2d;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            speed = 4f;
            rb2d.velocity = vect2d;
        }
        if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2))
        {
            speed = 0;
        }
        vect2d.x = speed;
        rb2d.velocity = vect2d;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.gameObject.transform.SetParent(transform);
        collision.transform.parent = transform;
    }
}
