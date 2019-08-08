using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameNow : MonoBehaviour
{
    private Saving scrSave;

    private void Start()
    {
        //objSave = GameObject.Find("Saving");
        //scrSave = objSave.GetComponent<Saving>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scrSave = GameObject.Find("Saving").GetComponent<Saving>();
            scrSave.Save(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}
