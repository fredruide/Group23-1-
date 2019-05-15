using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Enabler : MonoBehaviour
{
    private GameObject objWormController;
    private Worm_Controller scrWormController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Despawner")
        {
            if (null != GameObject.Find("Worm_Controller"))
            {
                objWormController = GameObject.Find("Worm_Controller");
                scrWormController = objWormController.GetComponent<Worm_Controller>();

                scrWormController.wormActionFinished = true;
            }
        }
    }
}
