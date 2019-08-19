using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int SpikeDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerScript player = collision.GetComponent<PlayerScript>();
            player.TakeDamage(SpikeDamage);
        }
    }
}
