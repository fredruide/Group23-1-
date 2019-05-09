using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public int rotationOffset = 90;

    void Update()
    {
        Vector3 difference = Camera.current.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

        if (Input.GetAxis("CamHorizontal") != 0 || Input.GetAxis("CamVertical") != 0)
        {
            rotZ = Mathf.Atan2(Input.GetAxis("CamHorizontal"), Input.GetAxis("CamVertical")) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, rotZ);
            Cursor.visible = true;
        }


    }
}
