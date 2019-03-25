using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTopTriggerScript : MonoBehaviour
{
    MainCameraScript mcs;
    //BoxCollider2D col;
    //BoxCollider2D parentCol;
    // Start is called before the first frame update
    void Start()
    {
        mcs = GetComponentInParent<MainCameraScript>();
        //col = GetComponent<BoxCollider2D>();
        //parentCol = GetComponentInParent<BoxCollider2D>();
        //col.size = new Vector2(parentCol.size.x, parentCol.size.y / 10);
        //col.offset = new Vector2(parentCol.size.x, parentCol.size.y / 2);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            mcs._topTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            mcs._topTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            mcs._topTrigger = false;
    }
}
