using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Disabler : MonoBehaviour
{
    private GameObject toDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Worm")
        {
            //Debug.Log(collision.gameObject.tag);
            toDestroy = collision.gameObject;
            Destroy(toDestroy);
            //Debug.Log(collision.gameObject);
        }
    }
}
