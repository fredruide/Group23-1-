using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanEnamyScript : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Grid grid;

    int directionFaced;

    #region AI_Variabler_And_Objects
    List<GameObject> openList;
    List<GameObject> closeList;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        grid = GameObject.Find("Grid").GetComponent<Grid>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void DirectionFaced()
    {
        if (rb.velocity.x > 0)
            directionFaced = 1;
        else if (rb.velocity.x < 0)
            directionFaced = -1;

        sr.flipX = true ? directionFaced > 0 : false;
    }
}
