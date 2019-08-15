using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToMob : MonoBehaviour
{
    public int hp;
    public float speed;
    public float dazedTime;
    public float startDazedTime;
    public int Damage;

    public GameObject bloodEffect;
    PlayerScript scrPlayer;

    Rigidbody2D MobRb;

    public GameObject Chest_Location;
    public GameObject Herb_Drop;
    public GameObject Stone_Drop;
    public GameObject Metal_Drop;
    public GameObject Wood_Drop;
    public GameObject Crystal_Drop;

    void Start()
    {
        scrPlayer = GameObject.Find("Player").GetComponent<PlayerScript>();
        MobRb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        //anim.SetBool("isRunning", true);
    }

    void Update()
    {

        if (dazedTime <= 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (hp < 1)
        {
            StartCoroutine("IELootDrop");
                        
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.name == "Player")
        //collision.gameObject.GetComponent<PlayerScript>().TakeDamage(Damage);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            scrPlayer.KnockbackSetter(100, 100, MobRb.position);
            scrPlayer.TakeDamage(Damage);
        }
    }
    public void TakeDmg(int dmg)
    {
        dazedTime = startDazedTime;
        hp -= dmg;
        Debug.Log("Damage taken " + dmg);
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
