using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    public int HP;
    public Rigidbody2D rb;

    public float knockbackX;
    public float knockbackY;
    public Vector3 playerPosition;

    public GameObject playerObject;
    private PlayerScript scrPlayer;
    public bool hasSeenPlayer;

    public float timeStamp;
    public bool isStunned;
         
    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("test3");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("test4");
            if (hasSeenPlayer == false)
            {
                Debug.Log("test5");
                playerObject = GameObject.Find("Player");
                scrPlayer = playerObject.GetComponent<PlayerScript>();
                hasSeenPlayer = true;
            }

        }
    }

    public void IsDisabled(bool MovementDisabled, float timer)
    {
        if (MovementDisabled)
        {
            Debug.Log("test6");
            timeStamp = Time.time + timer;
            isStunned = true;
        }
    }

    public void KnockbackSetter(float xForce, float yForce, Vector3 playerPosition)
    {
        Debug.Log("test8");
        knockbackX = xForce;
        knockbackY = yForce;
        playerObject.transform.position = playerPosition;
    }

    public void KnockBack()
    {
        Debug.Log("test9");
        IsDisabled(true, 0.6f);

        if (playerObject.transform.position.x >= rb.transform.position.x)
        {
            Debug.Log("test10");
            knockbackX = knockbackX * -1;
        }

        rb.velocity = new Vector2(knockbackX, knockbackY);

    }

    public void TakeDamage(int dmg)
    {
        Debug.Log("test11");
        HP -= dmg;
        KnockbackSetter(4, 4, playerObject.transform.position);
        KnockBack();
        
        if (HP <= 0)
        {
            Debug.Log("test12");
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("test13");
        //Implement lootdrop
        //Create death animation
        Destroy(gameObject);
    }
}
