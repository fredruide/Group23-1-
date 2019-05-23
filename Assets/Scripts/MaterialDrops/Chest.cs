using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Skrevet af Jonas C.
public class Chest : MonoBehaviour
{
    public GameObject Chest_Location;
    public GameObject Herb_Drop;
    public GameObject Stone_Drop;
    public GameObject Metal_Drop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("Open_Chest");       
        }


    }

    IEnumerator Open_Chest()
    {
        //Spawner mellem 0 og 10 stone
        for (int i = 0; i < UnityEngine.Random.Range(0, 10); i++)
        {
            Instantiate(Herb_Drop, Chest_Location.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }

        //Spawner mellem 0 og 10 stone
        for (int i = 0; i < UnityEngine.Random.Range(0, 10); i++)
        {
            Instantiate(Stone_Drop, Chest_Location.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }

        //Spawner mellem 0 og 10 metal
        for (int i = 0; i < UnityEngine.Random.Range(0, 10); i++)
        {
            Instantiate(Metal_Drop, Chest_Location.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
    }
}


