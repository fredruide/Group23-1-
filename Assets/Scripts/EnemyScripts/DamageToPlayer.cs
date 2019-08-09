using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    private GameObject objPlayer;
    private PlayerScript scrPlayer;
    private bool hasSeenPlayer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hasSeenPlayer == false)
            {
                objPlayer = GameObject.Find("Player");
                scrPlayer = objPlayer.GetComponent<PlayerScript>();
                hasSeenPlayer = true;
            }
            scrPlayer._canMoveHori = false;

            scrPlayer.KnockbackSetter(4, 4, transform.position);
            scrPlayer.TakeDamage(0);
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        objPlayer = GameObject.Find("Player");
        scrPlayer = objPlayer.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
