using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DamageToEnemy : MonoBehaviour
{
    public int HP;
    public Rigidbody2D MobRb;

    public float knockbackX;
    public float knockbackY;
    public Vector2 playerPosition;

    public GameObject playerObject;
    private PlayerScript scrPlayer;
    public bool hasSeenPlayer;

    public float timeStamp;
    public bool isStunned;

    public GameObject Herb_Drop;
    public GameObject Stone_Drop;
    public GameObject Metal_Drop;
    public GameObject Wood_Drop;
    public GameObject Crystal_Drop;

    private GameObject objScoreCounter;
    private ScoreCounter scrScoreCounter;


    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("test3");
        if (collision.gameObject.tag == "Player")
        {
            if (hasSeenPlayer == false)
            {
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
            timeStamp = Time.time + timer;
            isStunned = true;
        }
    }

    public void KnockbackSetter(float xForce, float yForce, Vector2 playerPosition)
    {
        knockbackX = xForce;
        knockbackY = yForce;
        playerObject.transform.position = playerPosition;
    }

    public void KnockBack()
    {
        IsDisabled(true, 0.6f);

        if (playerObject.transform.position.x >= MobRb.transform.position.x)
        {
            knockbackX = knockbackX * -1;
        }

        MobRb.velocity = new Vector2(knockbackX, knockbackY);

    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        KnockbackSetter(4, 4, playerObject.transform.position);
        KnockBack();

        if (HP < 1)
        {
            objScoreCounter = GameObject.Find("ScoreCounter");
            scrScoreCounter = objScoreCounter.GetComponent<ScoreCounter>();

            Die();

            scrScoreCounter.AddScore(20);
        }
    }

    public void Die()
    {
        StartCoroutine("IELootDrop");
        //Implement lootdrop
        //Create death animation
        

    }

    IEnumerator IELootDrop()
    {
        //Spawner mellem 0 og 10 stone
        for (int i = 0; i < UnityEngine.Random.Range(0, 10); i++)
        {
            Instantiate(Herb_Drop, MobRb.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }

        //Spawner mellem 0 og 10 stone
        for (int i = 0; i < UnityEngine.Random.Range(0, 10); i++)
        {
            Instantiate(Stone_Drop, MobRb.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }

        //Spawner mellem 0 og 10 metal
        for (int i = 0; i < UnityEngine.Random.Range(0, 10); i++)
        {
            Instantiate(Metal_Drop, MobRb.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < UnityEngine.Random.Range(0, 10); i++)
        {
            Instantiate(Wood_Drop, MobRb.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }

        for (int i = 0; i < UnityEngine.Random.Range(0, 1); i++)
        {
            Instantiate(Crystal_Drop, MobRb.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);

    }
}
