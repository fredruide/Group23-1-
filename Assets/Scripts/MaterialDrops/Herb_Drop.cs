using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Skrevet af Jonas C.
public class Herb_Drop : Drop_Template
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            toCarryOver = 10;

            Debug.Log(toCarryOver);
            if (null != GameObject.Find("Material_Counter"))
            {
                objMaterial_Counter = GameObject.Find("Material_Counter");
                scrMaterial_Counter = objMaterial_Counter.GetComponent<Material_Counter>();
                scrMaterial_Counter.CheckForHerb(toCarryOver);

                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
