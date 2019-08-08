using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : MonoBehaviour
{

    public int damage;
    public float attackSpeedCountdown;
    public float attackSpeed;
    GameObject playerObject;
    public GameObject axe;
    Animator animation;
    public Transform firePoint;
    Rigidbody2D minotaur;
    public float range;
    public Transform target;
    SpriteRenderer Sprite;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
        playerObject = GameObject.Find("Player"); 
        minotaur = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < range && attackSpeedCountdown <= 0)
        {
            animation.SetBool("IsAttacking", true);
        }
        else
        {
            attackSpeedCountdown -= Time.deltaTime;
        }
        Animation();
        //playerObject = new PlayerScript()
    }




    public void test()
    {
        animation.SetBool("IsAttacking", false);
        animation.Play("Idle", 0);
    }


    public void Animation()
    {

        if (minotaur.position.x > playerObject.transform.position.x)
        {
            Sprite.flipX = true;
        }

        if (minotaur.position.x < playerObject.transform.position.x)
        {
            Sprite.flipX = false;
        }
    }

    public void Fire()
    {
        Instantiate(axe, firePoint.position, firePoint.rotation);
        attackSpeedCountdown = attackSpeed;
    }

}