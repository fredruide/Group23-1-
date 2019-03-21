using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectJump : MonoBehaviour
{
    public bool jumpTrue;
    private Rigidbody2D rb2b;

    private void Start()
    {
        
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        print("sætter jumpTrue = true");
        if (collision.gameObject.tag == "Platform")
        {
            print("sætter jumpTrue = true");
            jumpTrue = true;
        }
        else
        {
            jumpTrue = false;
        }
    }
}
