﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 6;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{
    //    EnemyTest enemy = hitInfo.GetComponent<EnemyTest>();
    //    if (enemy != null)
    //    {
    //        EnemyTest.TakeDmg(damage);
    //    }
    //}

}
