using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaScript : DamageToEnemy
{
    Animator ani;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        playerObject = GameObject.Find("Player");
        MobRb = this.GetComponent<Rigidbody2D>();
        faceDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStamp <= Time.time)
        {
            isStunned = false;
        }

        //if (Input.GetKeyDown(KeyCode.PageDown))
        //{
        //    TakeDamage(1);
        //}

        if (isStunned == false)
        {
            MobRb.velocity = new Vector2(speed, MobRb.velocity.y);
        }
        
    }

    public void rotate()
    {
        speed = speed * -1.0f;
    }

    public void faceDirection()
    {
        if (speed > 0)
        {     
            transform.localScale = new Vector3(-2f, 2f, 1f);
        }

        if (speed < 0)
        {
            transform.localScale = new Vector3(2f, 2f, 1f);
        }
    }
}
