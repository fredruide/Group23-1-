using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameNow : MonoBehaviour
{
    public GameObject objSave;
    public Saving scrSave;

    private void Start()
    {
        objSave = GameObject.Find("Saving");
        scrSave = objSave.GetComponent<Saving>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scrSave.Save();
        }
    }
}
