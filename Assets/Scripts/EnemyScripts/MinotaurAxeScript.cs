using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAxeScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int tf = 5;
    public float axisSpeed;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    void FixedUpdate()
    {
        transform.Rotate(Vector3.back * axisSpeed);
    }


    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.gameObject.tag == "Player" || HitInfo.gameObject.tag == "Platform")
        {
            PlayerScript player = HitInfo.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.TakeDamage(tf);
            }

            Destroy(gameObject);
        }

    }
}
