using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion_Drop : Drop_Template
{//J.C.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            toCarryOver = 1;

            Debug.Log(toCarryOver);
            if (null != GameObject.Find("Material_Counter"))
            {
                objMaterial_Counter = GameObject.Find("Material_Counter");
                scrMaterial_Counter = objMaterial_Counter.GetComponent<Material_Counter>();
                scrMaterial_Counter.CheckForHPotion(toCarryOver);

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
