using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackflip : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

}
