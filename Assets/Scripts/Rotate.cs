using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public int rotationOffset = 90;
    private Vector3 tmpMousePosition;
    void Start()
    {
        tmpMousePosition = Input.mousePosition;
    }
    void Update()
    {
        float rotZ;
        if ((Input.GetAxis("CamHorizontal") != 0 || Input.GetAxis("CamVertical") != 0) && Input.GetJoystickNames().Length > 0)
        {
            rotationOffset = 0;
            rotZ = Mathf.Atan2(Input.GetAxis("CamVertical"), Input.GetAxis("CamHorizontal")) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
        }
    
        else if (tmpMousePosition != Input.mousePosition)
        {
            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            difference.Normalize();
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
            tmpMousePosition = Input.mousePosition;
        }
        
       


    }
}
