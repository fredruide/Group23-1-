using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    private Animator anim;
    public GameObject blood;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
        
    }

    void Update()
        
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void TakeDamage (float Damage)
    {
        health -= Damage;
        Debug.Log("Damage taken " + Damage);
        Debug.Log("Attack stopped");
    }
}
