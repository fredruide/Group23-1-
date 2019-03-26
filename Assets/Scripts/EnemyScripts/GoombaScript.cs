using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaScript : MonoBehaviour
{
    public Collider2D terrainTrigger;
    public Collider2D oldTerrainTrigger;
    Rigidbody2D rb2d;
    Animator ani;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(10, 10);
    }

    // Update is called once per frame
    void Update()
    {        
        VerticalMovement();
        oldTerrainTrigger = terrainTrigger;
    }

    public void VerticalMovement()
    {
        if (oldTerrainTrigger != terrainTrigger && (terrainTrigger.gameObject.tag == "Wall" || terrainTrigger.gameObject.tag == "Platform"))
        {
            speed = speed * -1;
        }
      
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        if (speed > 0)
        {
           
            transform.localScale = new Vector3(-4.82f, 5f, 1f);
        }

        if (speed < 0)
        {
            transform.localScale = new Vector3(4.82f, 5f, 1f);
        }
    }
}
