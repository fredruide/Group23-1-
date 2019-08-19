using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorMove : DamageToEnemy
{
    public float Speed;

    public float playerRange;

    public LayerMask playerLayer;

    public bool PlayerInRange;

    SpriteRenderer GatorSprite;

    // Start is called before the first frame update
    public void Start()
    {

        playerLayer = LayerMask.GetMask("Player");
        playerObject = GameObject.Find("Player");
        MobRb = this.GetComponent<Rigidbody2D>();

        GatorSprite = GetComponent<SpriteRenderer>();

        
        //Physics2D.IgnoreLayerCollision(11, 11);
        //Physics2D.IgnoreLayerCollision(10, 11);
    }

    // Update is called once per frame
    public void Update()
    {
        if (timeStamp <= Time.time)
        {
            isStunned = false;
        }

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            TakeDamage(1);
        }

        Vector2 direction = playerObject.transform.position - MobRb.transform.position;
        direction.Normalize();
        Vector2 velocity = direction * Speed;
        
        PlayerInRange = Physics2D.OverlapCircle(MobRb.transform.position, playerRange, playerLayer);

        if (PlayerInRange && isStunned == false)
        {
            Speed = 5.0f;
            MobRb.velocity = new Vector2(velocity.x, velocity.y);
        }

        if (!PlayerInRange && isStunned == false)
        {
            MobRb.velocity = new Vector2(0, 0);
        }

        Animation();  
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }

    public void Animation()
    {
       
        if (MobRb.position.x > playerObject.transform.position.x)
        {
            GatorSprite.flipX = false;
        }

        if (MobRb.position.x < playerObject.transform.position.x)
        {
            GatorSprite.flipX = true;
        }
    }
}


