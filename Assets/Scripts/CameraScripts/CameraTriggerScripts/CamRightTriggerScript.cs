using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRightTriggerScript : MonoBehaviour
{
    MainCameraScript mcs;
    // Start is called before the first frame update
    void Start()
    {
        mcs = GetComponentInParent<MainCameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            mcs._rightTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            mcs._rightTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            mcs._rightTrigger = false;
    }
}
