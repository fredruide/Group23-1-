using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int tf= 5;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.gameObject.tag == "Enemy" || HitInfo.gameObject.tag == "Platform")
        {
            EnemyTest Enemy = HitInfo.GetComponent<EnemyTest>();
            if (Enemy != null)
            {
                Enemy.TakeDmg(tf);
            }

            Destroy(gameObject);
        }

    }
}
