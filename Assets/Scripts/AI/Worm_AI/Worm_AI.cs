﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_AI : MonoBehaviour
{
    public GameObject objWormController;
    public GameObject objPlatforms;
    private Worm_Controller scrWormController; 
    private Rigidbody2D rb2d;
    private Vector2 speed;
    private CompositeCollider2D compCollid;
    private BoxCollider2D collid;
    public float test;

    // Start is called before the first frame update
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
        //Physics2D.IgnoreLayerCollision(11, 12, false);
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), objPlatforms.GetComponent<CompositeCollider2D>());
    }

    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(scrWormController.horizontalSpeed);
        speed.x = 4;
        
        rb2d.velocity = new Vector2(scrWormController.horizontalSpeed, 0);
        //Debug.Log(rb2d.velocity);
        //Debug.Log(collid.bounds.size);
    }
}
