using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorMove : MonoBehaviour
{
    GameObject playerObject;

    

    public float Speed;

    public float playerRange;

    public LayerMask playerLayer;

    public bool PlayerInRange;

    Rigidbody2D Gator;

    SpriteRenderer GatorSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        

        playerLayer = LayerMask.GetMask("Player");

        Gator = GetComponent<Rigidbody2D>();
        GatorSprite = GetComponent<SpriteRenderer>();

        //Physics2D.IgnoreLayerCollision(11, 11);
        //Physics2D.IgnoreLayerCollision(10, 11);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerObject.transform.position - transform.position;
        direction.Normalize();
        Vector3 velocity = direction * Speed;

        PlayerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        if (PlayerInRange)
        {
            Speed = 5.0f;
            Gator.velocity = new Vector2(velocity.x, velocity.y);
        }

        if (!PlayerInRange)
        {
            Gator.velocity = new Vector2(0, 0);
        }

        Animation();  
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }

    public void Animation()
    {
       
        if (Gator.position.x > playerObject.transform.position.x)
        {
            GatorSprite.flipX = false;
        }

        if (Gator.position.x < playerObject.transform.position.x)
        {
            GatorSprite.flipX = true;
        }
    }
}


