using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathpit : MonoBehaviour
{
    PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Info)
    {
        if (Info.gameObject.tag == "Player")
        {
            player = Info.GetComponent<PlayerScript>();
            player.Die();
        }
        else
        {
            Destroy(Info.gameObject);
        }
    }
}
