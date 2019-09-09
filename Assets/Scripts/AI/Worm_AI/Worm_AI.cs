using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_AI : MonoBehaviour
{
    public GameObject objWormController;
    public GameObject objPlatforms;
    public GameObject player;

    private Worm_Controller scrWormController; 
    private Rigidbody2D rb2d;
    private Vector2 speed;

    void Start()
    {        
        rb2d = GetComponent<Rigidbody2D>();
        if (null != GameObject.Find("Worm_Controller"))
        {
            objWormController = GameObject.Find("Worm_Controller");
            scrWormController = objWormController.GetComponent<Worm_Controller>();
        }
        if (null != GameObject.Find("Tilemap_Platforms"))
        {
            objPlatforms = GameObject.Find("Tilemap_Platforms");
        }
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), objPlatforms.GetComponent<CompositeCollider2D>());
    }

    void Update()
    {
        speed.x = 4;        
        rb2d.velocity = new Vector2(scrWormController.horizontalSpeed, 0);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.transform.SetParent(gameObject.transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.transform.SetParent(null);
        }
    }
}
